using System;
using System.Collections.Generic;
using Aki.Config;
using UnrealEngine;

// Token: 0x02001D32 RID: 7474
public class CollectionTypeItem : SyncGridProxyAbstract<MotorFightItemType>
{
	// Token: 0x0600DC12 RID: 56338 RVA: 0x003B278C File Offset: 0x003B098C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUISprite))
		};
	}

	// Token: 0x0600DC13 RID: 56339 RVA: 0x003B27C8 File Offset: 0x003B09C8
	public override void Refresh(MotorFightItemType data)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), data.Name, Array.Empty<object>());
		this.SetSpriteByPath(data.Icon, base.GetSprite(1), false, null, null);
	}

	// Token: 0x020080C3 RID: 32963
	private static class EComponents
	{
		// Token: 0x0402BC9D RID: 179357
		public const int TextTypeName = 0;

		// Token: 0x0402BC9E RID: 179358
		public const int SpriteIcon = 1;
	}
}
