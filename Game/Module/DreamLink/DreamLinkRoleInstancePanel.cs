using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.DreamLink
{
	// Token: 0x02005DA5 RID: 23973
	public class DreamLinkRoleInstancePanel : UiPanelBase
	{
		// Token: 0x0603C5B6 RID: 247222 RVA: 0x00F50D9C File Offset: 0x00F4EF9C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603C5B7 RID: 247223 RVA: 0x00F50E28 File Offset: 0x00F4F028
		protected override UniTask OnBeforeStartAsync()
		{
			DreamLinkRoleInstancePanel.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<DreamLinkRoleInstancePanel.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603C5B8 RID: 247224 RVA: 0x00F50E6C File Offset: 0x00F4F06C
		[NullableContext(1)]
		public void Refresh(RogueRoleInstData[] dungeonList, int selectIndex)
		{
			for (int i = 0; i < this.RoleDungeonItemList.Count; i++)
			{
				if (i < dungeonList.Length)
				{
					this.RoleDungeonItemList[i].Refresh(dungeonList[i], i == selectIndex);
				}
			}
		}

		// Token: 0x0603C5B9 RID: 247225 RVA: 0x00F50EB0 File Offset: 0x00F4F0B0
		public FVector2D? GetScreenPositionByIndex(int index)
		{
			DreamLinkRoleInstanceItem dreamLinkRoleInstanceItem = this.RoleDungeonItemList[index];
			if (dreamLinkRoleInstanceItem != null)
			{
				return new FVector2D?(dreamLinkRoleInstanceItem.GetRootItem().GetPositionInViewPort(true));
			}
			return null;
		}

		// Token: 0x0603C5BA RID: 247226 RVA: 0x00F50EE8 File Offset: 0x00F4F0E8
		public FVectorDouble? GetLocationByIndex(int index)
		{
			DreamLinkRoleInstanceItem dreamLinkRoleInstanceItem = this.RoleDungeonItemList[index];
			if (dreamLinkRoleInstanceItem != null)
			{
				return new FVectorDouble?(dreamLinkRoleInstanceItem.GetRootItem().D_K2_GetComponentToWorld().GetLocation());
			}
			return null;
		}

		// Token: 0x0603C5BB RID: 247227 RVA: 0x00F50F28 File Offset: 0x00F4F128
		public void SetSelectItem(int index)
		{
			for (int i = 0; i < this.RoleDungeonItemList.Count; i++)
			{
				if (i != index)
				{
					this.RoleDungeonItemList[i].SetToggleState(false);
				}
			}
		}

		// Token: 0x04021EFF RID: 139007
		[Nullable(1)]
		private readonly List<DreamLinkRoleInstanceItem> RoleDungeonItemList = new List<DreamLinkRoleInstanceItem>();

		// Token: 0x0200BDCE RID: 48590
		private class EComponentDefine
		{
			// Token: 0x0403A719 RID: 239385
			public const int Item1 = 0;

			// Token: 0x0403A71A RID: 239386
			public const int Item2 = 1;

			// Token: 0x0403A71B RID: 239387
			public const int Item3 = 2;
		}
	}
}
