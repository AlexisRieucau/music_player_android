using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace music_player_android.Interfaces
{
    interface ILocalize
    {
        CultureInfo GetCurrentCultureInfo();
        void SetLocale(CultureInfo ci);
    }
}
