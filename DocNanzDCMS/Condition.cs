using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocNanzDCMS
{
    public enum Condition
    {
        DECAYED,
        MISSING_DUE_TO_CARIES,
        FILLED,
        CARIES_INDICATED_FOR_EXTRACTION,
        ROOT_FRAGMENT,
        MISSING_DUE_TO_OTHER_CAUSES,
        IMPACTED_TOOTH
    }
}
