using System.ComponentModel;

namespace WorkedHourControl.Domain.Entities
{
    public enum Profile
    {
        [Description("Gestor")]
        Manager = 1,
        [Description("Colaborador")]
        Employee = 2
    }
}
