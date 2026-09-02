using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Skin.Role.Item
{
	// Token: 0x02004F75 RID: 20341
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RoleSkinObtainItem : GridProxyAbstract<IGetWayItemData>
	{
		// Token: 0x0603476F RID: 214895 RVA: 0x00D20CD4 File Offset: 0x00D1EED4
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIText)),
				new ValueTuple<int, Type>(4, typeof(UUIText))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(this.OnClick))
			};
		}

		// Token: 0x06034770 RID: 214896 RVA: 0x00D20D7D File Offset: 0x00D1EF7D
		private void OnClick()
		{
			if (this.Data.Type == EGetWayItemType.CanJump)
			{
				SkipTaskManager.RunByConfigId(this.Data.Id, this.Data.Id);
			}
		}

		// Token: 0x06034771 RID: 214897 RVA: 0x00D20DB0 File Offset: 0x00D1EFB0
		public override void Refresh(IGetWayItemData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			bool flag = this.Data.Type == EGetWayItemType.CanJump;
			UUIItem item = base.GetItem(1);
			if (item != null)
			{
				item.SetUIActive(flag);
			}
			UUIItem item2 = base.GetItem(2);
			if (item2 != null)
			{
				item2.SetUIActive(!flag);
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), this.Data.Text, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), this.Data.Text, Array.Empty<object>());
		}

		// Token: 0x0401E378 RID: 123768
		private IGetWayItemData Data;

		// Token: 0x0200AF92 RID: 44946
		[NullableContext(0)]
		private enum EComponentDefine
		{
			// Token: 0x040367C6 RID: 223174
			Button,
			// Token: 0x040367C7 RID: 223175
			UnlockItem,
			// Token: 0x040367C8 RID: 223176
			LockItem,
			// Token: 0x040367C9 RID: 223177
			Name,
			// Token: 0x040367CA RID: 223178
			LockName
		}
	}
}
