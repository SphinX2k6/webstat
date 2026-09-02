using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Plot.PlotView;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A37 RID: 18999
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class SceneUiViewManager : Singleton<SceneUiViewManager>
	{
		// Token: 0x06031A5D RID: 203357 RVA: 0x00C5E7A4 File Offset: 0x00C5C9A4
		public void Init()
		{
			SceneUiStorage instance = Singleton<SceneUiStorage>.Instance;
			ValueTuple<string, Func<SceneUiView>, string>[] array = new ValueTuple<string, Func<SceneUiView>, string>[1];
			array[0] = new ValueTuple<string, Func<SceneUiView>, string>("PlotSequenceSceneWordArtView", () => new PlotSequenceSceneWordArtView(), "UiView_MainStoryTextB");
			instance.Register(array);
		}
	}
}
