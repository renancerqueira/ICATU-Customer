using AutoMapper;
using ICATU.Costumer.Domain.Models;
using ICATU.Infra.Data.Mapping;

namespace ICATU.Costumer.Service.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize((config) =>
            {

                config.CreateMap<Cliente, ClienteModel>()
                      .ForMember(dest => dest.Cpf, opt => opt.ResolveUsing(src => new CpfModel(src.Cpf)));

                config.CreateMap<ClienteModel, Cliente>()
                      .ForMember(dest => dest.Cpf, opt => opt.ResolveUsing(src =>  src.Cpf.Numero));

                config.CreateMap<Endereco, EnderecoModel>()
                      .ReverseMap();

            });
        }
    }
}
