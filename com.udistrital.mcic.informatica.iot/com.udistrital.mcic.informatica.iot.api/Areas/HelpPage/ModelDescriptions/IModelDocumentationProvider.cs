using System;
using System.Reflection;

namespace com.udistrital.mcic.informatica.iot.api.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}