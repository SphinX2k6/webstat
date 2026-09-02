using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A5B RID: 19035
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class UiTabViewStorage : Singleton<UiTabViewStorage>
	{
		// Token: 0x06031B83 RID: 203651 RVA: 0x00C63FB0 File Offset: 0x00C621B0
		public IUiTabViewTsInfo GetUiTabViewBase(EUiTabViewName tabViewName)
		{
			IUiTabViewTsInfo result;
			this.UiTabViewStorageMap.TryGetValue(tabViewName, out result);
			return result;
		}

		// Token: 0x06031B84 RID: 203652 RVA: 0x00C63FD0 File Offset: 0x00C621D0
		public void AddUiTabViewBase([Nullable(new byte[]
		{
			1,
			0,
			1,
			1
		})] ValueTuple<EUiTabViewName, Type, string>[] uiTabViewTsInfoList)
		{
			for (int i = 0; i < uiTabViewTsInfoList.Length; i++)
			{
				ValueTuple<EUiTabViewName, Type, string> uiTabViewTsInfo = uiTabViewTsInfoList[i];
				this.UiTabViewStorageMap[uiTabViewTsInfo.Item1] = new UiTabViewTsInfo(() => (UiTabViewBase)Activator.CreateInstance(uiTabViewTsInfo.Item2), uiTabViewTsInfo.Item3);
			}
		}

		// Token: 0x0401CEB8 RID: 118456
		private readonly Dictionary<EUiTabViewName, IUiTabViewTsInfo> UiTabViewStorageMap = new Dictionary<EUiTabViewName, IUiTabViewTsInfo>();
	}
}
