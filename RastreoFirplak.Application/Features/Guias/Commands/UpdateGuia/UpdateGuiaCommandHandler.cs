using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using RastreoFirplak.Application.Contracts.Infrastructure;
using RastreoFirplak.Application.Contracts.Persistence;
using RastreoFirplak.Application.Exceptions;
using RastreoFirplak.Application.Models;
using RastreoFirplak.Domain;

namespace RastreoFirplak.Application.Features.Guias.Commands.UpdateGuia
{
    public class UpdateGuiaCommandHandler : IRequestHandler<UpdateGuiaCommand, Unit>
    {
        private readonly IGuiaRepository _guiaRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<UpdateGuiaCommandHandler> _logger;

        public UpdateGuiaCommandHandler(IGuiaRepository guiaRepository, IMapper mapper, IEmailService emailService, ILogger<UpdateGuiaCommandHandler> logger)
        {
            _guiaRepository = guiaRepository;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateGuiaCommand request, CancellationToken cancellationToken)
        {
            var guiaToUpdate = await _guiaRepository.GetByIdAsync(request.Id);

            if (guiaToUpdate == null)
            {
                _logger.LogError($"No se encontró la guia id {request.Id}");
                throw new NotFoundException(nameof(Guia), request.Id);
            }

            _mapper.Map(request, guiaToUpdate, typeof(UpdateGuiaCommand), typeof(Guia));

            var guia = await _guiaRepository.UpdateAsync(guiaToUpdate);

            _logger.LogInformation($"Guia {guia.Id} actualizada exitosamente");

            //Si se actualiza la fecha de entregado se envia el correo
            // await SendEmail(guia);
            return Unit.Value;
        }

        private async Task SendEmail(Guia guia)
        {
            var email = new Email
            {
                To = guia.Correotransportador,
                Body = $"Recuerda ajuntar el POD de la guía {guia.NumeroGuia}",
                Subject = $"ADJUNTA POD - GUIA #{guia.NumeroGuia}"
            };

            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {
                _logger.LogError($"No se pudo enviar el correo de alerta POD de la guia {guia.NumeroGuia}");
            };
        }
    }
}
