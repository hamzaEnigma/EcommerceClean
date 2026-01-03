using AutoMapper;
using Ecommerce.Application.Orders.Dtos;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Orders.Profilers
{
    public class OrderProfiler : Profile
    {
        public OrderProfiler()
        {
            CreateMap<Order, OrderDTO>();
            CreateMap<OrderDetail, OrderDetailsDto>();
            CreateMap<OrderDTO, Order>();
            CreateMap<OrderDetailsDto, OrderDetail>();
        }
    }
}
