using System;
using System.Runtime.CompilerServices;

// Token: 0x02001C8A RID: 7306
[NullableContext(1)]
[Nullable(0)]
internal class TabItemData
{
	// Token: 0x0400656C RID: 25964
	[Nullable(2)]
	public FragmentMemoryCollectData FragmentCollectData;

	// Token: 0x0400656D RID: 25965
	public Action<int> TabCallBack = delegate(int value)
	{
	};

	// Token: 0x0400656E RID: 25966
	public Func<int> GetCurrentSelectTabIndex = () => 0;

	// Token: 0x0400656F RID: 25967
	public bool NeedSwitchAnimation;
}
