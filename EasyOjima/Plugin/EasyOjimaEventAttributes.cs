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
    public class OnLoadEventAttribute : EasyOjimaEventAttributes { }

    /// <summary>
    /// アプリ終了時に実行されるイベントです
    /// </summary>
    public class OnUnloadEventAttribute : EasyOjimaEventAttributes { }

    /// <summary>
    /// 動画再生時に実行されるイベントです
    /// </summary>
    public class OnPlayEventAttribute : EasyOjimaEventAttributes { }

    /// <summary>
    /// 再生画面のフレームが変わった後に実行されるイベントです
    /// </summary>
    public class OnFrameUpdateEventAttribute : EasyOjimaEventAttributes { }

    /// <summary>
    /// 動画ファイルを読み込んだ後に実行されるイベントです
    /// </summary>
    public class OnLoadVideoEventAttribute : EasyOjimaEventAttributes { }

    /// <summary>
    /// 動画をエクスポートする直前に実行されるイベントです
    /// </summary>
    public class OnExportVideoEventAttribute : EasyOjimaEventAttributes { }

    /// <summary>
    /// MainViewの、System.Drawingのpaintイベントです
    /// この属性を使う場合、メソッドの引数に(object sender, PaintEventArgs e)を指定する必要があります
    /// </summary>
    public class OnPaintEventAttribute : EasyOjimaEventAttributes { }
}
