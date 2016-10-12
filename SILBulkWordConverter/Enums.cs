﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILConvertersWordML
{
    public enum ConversionMode
    {
        BasicUserMode,
        ExpertUserMode
    }

    public enum MessageType
    {
        UserMessage,    // Can be shown to the user
        UserErrorMessage,
        SystemMessage,  // Technical Message that can be logged for technical review
        SystemErrorMessage,
        ControlMessage  // For the request/response from the user
    }

    public enum ConversionElements
    {
        FontsAndStyles,
        FontsAlone,
        StylesAlone
    }

    public enum MessageLevel
    {
        Normal,
        Critical
    }
}