using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProBarbearia.Application.Contratos;
using ProBarbearia.Persistence.Contratos;
using AutoMapper;
using ProBarbearia.Application.Dtos;

namespace ProBarbearia.Application.Services
{
    public class ProfissionalServico : IProfissionalServico
    {
        private readonly IGeralPersistencia _geralPersistencia;
        private readonly IProfissionalPersistencia _profissionalPersistencia;
        private readonly IMapper _mapper;
        public ProfissionalServico(IGeralPersistencia geralPersistencia,
                             IProfissionalPersistencia profissionalPersistencia,
                             IMapper mapper)
        {
            _geralPersistencia = geralPersistencia;
            _profissionalPersistencia = profissionalPersistencia;
            _mapper = mapper;
        }

        public async Task<ProfissionalRetornoDto[]> CarregaProfissionais(int estabelecimentoId)
        {
            try
            {
                var profissionais = await _profissionalPersistencia.CarregaProfissionais(estabelecimentoId);
                if (profissionais == null) return null;

                
                var resultado = _mapper.Map<ProfissionalRetornoDto[]>(profissionais);

                

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

       
    }
}