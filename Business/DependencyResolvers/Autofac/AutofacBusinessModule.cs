using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Http;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AddressManager>().As<IAddressService>();
            builder.RegisterType<EfAddressDal>().As<IAddressDal>();

            builder.RegisterType<BloodTypeManager>().As<IBloodTypeService>();
            builder.RegisterType<EfBloodTypeDal>().As<IBloodTypeDal>();

            builder.RegisterType<CityManager>().As<ICityService>();
            builder.RegisterType<EfCityDal>().As<ICityDal>();

            builder.RegisterType<DistrictManager>().As<IDistrictService>();
            builder.RegisterType<EfDistrictDal>().As<IDistrictDal>();

            builder.RegisterType<DriverLicenseManager>().As<IDriverLicenseService>();
            builder.RegisterType<EfDriverLicenseDal>().As<IDriverLicenseDal>();

            builder.RegisterType<ManagementManager>().As<IManagementService>();
            builder.RegisterType<EfManagementDal>().As<IManagementDal>();

            builder.RegisterType<MemberManager>().As<IMemberService>();
            builder.RegisterType<EfMemberDal>().As<IMemberDal>();

            builder.RegisterType<NeighbourhoodManager>().As<INeighbourhoodService>();
            builder.RegisterType<EfNeighbourhoodDal>().As<INeighbourhoodDal>();

            builder.RegisterType<PersonalInformationManager>().As<IPersonalInformationService>();
            builder.RegisterType<EfPersonalInformationDal>().As<IPersonalInformationDal>();

            builder.RegisterType<StreetManager>().As<IStreetService>();
            builder.RegisterType<EfStreetDal>().As<IStreetDal>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>();


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}