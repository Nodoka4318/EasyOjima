using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace EasyOjima.Plugin {
    //一応制限
    [AttributeUsage(AttributeTargets.Method)]
    public class EasyOjimaEventAttributes : Attribute {
        public EasyOjimaEventAttributes() : base() { }
    }

    //以下属性たち    

    /// <summary>
    /// アプリ起動時に実行されるイベントです
    /// </summary>
    public class OnLoadEvent : EasyOjimaEventAttributes { }

    /// <summary>
    /// アプリ終了時に実行されるイベントです
    /// </summary>
    public class OnUnloadEvent : EasyOjimaEventAttributes { }

    /// <summary>
    /// 動画再生時に実行されるイベントです
    /// </summary>
    public class OnPlayEvent : EasyOjimaEventAttributes { }
}
