using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A35 RID: 18997
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class SceneUiStorage : Singleton<SceneUiStorage>
	{
		// Token: 0x06031A49 RID: 203337 RVA: 0x00C5E3DD File Offset: 0x00C5C5DD
		[return: Nullable(2)]
		public SceneUiInfo Get(string viewName)
		{
			return this.SceneUiInfoMap.GetValueOrDefault(viewName);
		}

		// Token: 0x06031A4A RID: 203338 RVA: 0x00C5E3EC File Offset: 0x00C5C5EC
		public void Register([TupleElementNames(new string[]
		{
			"ViewName",
			"CreateView",
			"ResourceId"
		})] [Nullable(new byte[]
		{
			1,
			0,
			1,
			1,
			1,
			1
		})] ValueTuple<string, Func<SceneUiView>, string>[] sceneUiInfoList)
		{
			foreach (ValueTuple<string, Func<SceneUiView>, string> valueTuple in sceneUiInfoList)
			{
				string item = valueTuple.Item1;
				if (this.SceneUiInfoMap.ContainsKey(item))
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Scene3dUi;
					ELogAuthor author = ELogAuthor.HYF;
					string message = "[SceneUiStorage]重复注册";
					ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("ViewName", item);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				}
				else
				{
					this.SceneUiInfoMap[item] = new SceneUiInfo
					{
						CreateView = valueTuple.Item2,
						ResourceId = valueTuple.Item3
					};
				}
			}
		}

		// Token: 0x0401CE47 RID: 118343
		private readonly Dictionary<string, SceneUiInfo> SceneUiInfoMap = new Dictionary<string, SceneUiInfo>();
	}
}
