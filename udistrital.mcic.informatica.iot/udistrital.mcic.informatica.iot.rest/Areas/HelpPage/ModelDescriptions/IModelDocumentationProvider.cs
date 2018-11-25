using System;
using System.Reflection;

namespace udistrital.mcic.informatica.iot.rest.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}