using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A52 RID: 19026
	[NullableContext(1)]
	[Nullable(0)]
	public class UiPrefabLoadModule
	{
		// Token: 0x06031B67 RID: 203623 RVA: 0x00C63C38 File Offset: 0x00C61E38
		[return: Nullable(new byte[]
		{
			0,
			2
		})]
		public UniTask<AActor> LoadPrefabAsync(string path, [Nullable(2)] UUIItem parent, string memoryTag = "js_undefined")
		{
			UiPrefabLoadModule.<LoadPrefabAsync>d__1 <LoadPrefabAsync>d__;
			<LoadPrefabAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<AActor>.Create();
			<LoadPrefabAsync>d__.<>4__this = this;
			<LoadPrefabAsync>d__.path = path;
			<LoadPrefabAsync>d__.parent = parent;
			<LoadPrefabAsync>d__.memoryTag = memoryTag;
			<LoadPrefabAsync>d__.<>1__state = -1;
			<LoadPrefabAsync>d__.<>t__builder.Start<UiPrefabLoadModule.<LoadPrefabAsync>d__1>(ref <LoadPrefabAsync>d__);
			return <LoadPrefabAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06031B68 RID: 203624 RVA: 0x00C63C94 File Offset: 0x00C61E94
		public void Clear()
		{
			foreach (KeyValuePair<int, string> keyValuePair in this.PrefabIdSet)
			{
				int key = keyValuePair.Key;
				string value = keyValuePair.Value;
				Singleton<ResourceSystem>.Instance.CancelAsyncLoad(key);
			}
			this.PrefabIdSet.Clear();
		}

		// Token: 0x0401CEB0 RID: 118448
		private readonly Dictionary<int, string> PrefabIdSet = new Dictionary<int, string>();
	}
}
