using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A51 RID: 19025
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class UiPopFrameViewStorage : Singleton<UiPopFrameViewStorage>
	{
		// Token: 0x06031B64 RID: 203620 RVA: 0x00C63BF5 File Offset: 0x00C61DF5
		public void RegisterUiBehaviourPop(int type, UiPopFrameViewInfo info)
		{
			this.UiBehaviourPopMap[type] = info;
		}

		// Token: 0x06031B65 RID: 203621 RVA: 0x00C63C04 File Offset: 0x00C61E04
		[NullableContext(2)]
		public UiPopFrameViewInfo GetUiBehaviourPopInfo(int type)
		{
			UiPopFrameViewInfo result;
			if (!this.UiBehaviourPopMap.TryGetValue(type, out result))
			{
				return null;
			}
			return result;
		}

		// Token: 0x0401CEAF RID: 118447
		private readonly Dictionary<int, UiPopFrameViewInfo> UiBehaviourPopMap = new Dictionary<int, UiPopFrameViewInfo>();
	}
}
