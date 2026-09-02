using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x0200515A RID: 20826
	public class RoguelikeRoleSelectPanel : UiPanelBase
	{
		// Token: 0x060359AA RID: 219562 RVA: 0x00D76F08 File Offset: 0x00D75108
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.OnClickEntrance));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060359AB RID: 219563 RVA: 0x00D77032 File Offset: 0x00D75232
		private void OnClickEntrance()
		{
			Action clickEntranceFunc = this.ClickEntranceFunc;
			if (clickEntranceFunc == null)
			{
				return;
			}
			clickEntranceFunc();
		}

		// Token: 0x060359AC RID: 219564 RVA: 0x00D77044 File Offset: 0x00D75244
		protected override UniTask OnBeforeStartAsync()
		{
			RoguelikeRoleSelectPanel.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoguelikeRoleSelectPanel.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060359AD RID: 219565 RVA: 0x00D77088 File Offset: 0x00D75288
		[NullableContext(1)]
		public void Refresh(RoguelikeEntranceViewModel viewModel)
		{
			List<int> formationIdList = viewModel.FormationIdList;
			for (int i = 0; i < 3; i++)
			{
				this.RoleSelectItemList[i].Refresh(formationIdList[i]);
			}
		}

		// Token: 0x060359AE RID: 219566 RVA: 0x00D770C0 File Offset: 0x00D752C0
		public void ShowNewUnlockRole(bool isShow)
		{
			this.RoleSelectItemList[0].ShowNewUnlockRole(isShow);
		}

		// Token: 0x0401ECA2 RID: 126114
		[Nullable(1)]
		private readonly List<RoguelikeRoleSelectItem> RoleSelectItemList = new List<RoguelikeRoleSelectItem>();

		// Token: 0x0401ECA3 RID: 126115
		[Nullable(2)]
		public Action<int> ClickRoleItemFunc;

		// Token: 0x0401ECA4 RID: 126116
		[Nullable(2)]
		public Action ClickEntranceFunc;

		// Token: 0x0200B107 RID: 45319
		private class EComponents
		{
			// Token: 0x04036E9C RID: 224924
			public const int TexLevel = 0;

			// Token: 0x04036E9D RID: 224925
			public const int TxtLevel = 1;

			// Token: 0x04036E9E RID: 224926
			public const int RoleItem1 = 2;

			// Token: 0x04036E9F RID: 224927
			public const int RoleItem2 = 3;

			// Token: 0x04036EA0 RID: 224928
			public const int RoleItem3 = 4;

			// Token: 0x04036EA1 RID: 224929
			public const int BtnEntrance = 5;
		}
	}
}
