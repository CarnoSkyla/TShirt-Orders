using System;
using System.Collections.Generic;
using System.Text;

namespace TShirtOrders
{
    public interface ITextToSpeech
    {
        void Speak(string text);
    }
}
