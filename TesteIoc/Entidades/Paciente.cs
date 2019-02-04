using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Paciente
    {
        [ColunaBD("FIC_INICIAL_ID")]
        public int Codigo { get; set; }

        [ColunaBD("NOME")]
        public string Nome { get; set; }

        [ColunaBD("SOBRENOME")]
        public string Sobrenome { get; set; }

        [ColunaBD("PHONE")]
        public string celular { get; set; }

        [ColunaBD("OPTION_TEL1")]
        public string OptionCel1 { get; set; }

        [ColunaBD("OPTION_TEL2")]
        public string OptionCel2 { get; set; }

        [ColunaBD("OPTION_TEL3")]
        public string OptionCel3 { get; set; }

        [ColunaBD("CFPB_PTNH_COD")]
        public string CodigoProgramaTNH { get; set; }

        public string ProcedureDate { get; set; }

        [ColunaBD("OPTION_CARTEIRINHA_GNDI")]
        public string OptionCarteirinhaIntermedica { get; set; }

        [ColunaBD("KEY")]
        public string PacienteKey { get; set; }

        [ColunaBD("SECRET")]
        public string PacienteSecret { get; set; }
    }
}
