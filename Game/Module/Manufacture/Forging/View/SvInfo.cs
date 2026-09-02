using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Manufacture.Forging.View
{
	// Token: 0x020059AD RID: 22957
	[NullableContext(1)]
	[Nullable(0)]
	public class SvInfo : UiPanelBase
	{
		// Token: 0x0603A1CD RID: 238029 RVA: 0x00EB53C0 File Offset: 0x00EB35C0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIVerticalLayout));
			this.ComponentRegisterInfos = list;
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>();
		}

		// Token: 0x0603A1CE RID: 238030 RVA: 0x00EB54B8 File Offset: 0x00EB36B8
		protected override UniTask OnBeforeStartAsync()
		{
			SvInfo.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SvInfo.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603A1CF RID: 238031 RVA: 0x00EB54FB File Offset: 0x00EB36FB
		protected override void OnStart()
		{
			this.WeaponAttributeComponent.SetActive(true);
		}

		// Token: 0x0603A1D0 RID: 238032 RVA: 0x00EB550C File Offset: 0x00EB370C
		public void SetTypeName(string tag = null)
		{
			UUIText text = base.GetText(0);
			if (!string.IsNullOrEmpty(tag))
			{
				text.SetUIActive(true);
				text.SetText(tag, true);
				return;
			}
			text.SetUIActive(false);
		}

		// Token: 0x0603A1D1 RID: 238033 RVA: 0x00EB5540 File Offset: 0x00EB3740
		public void SetTypeNameVisible(bool visible)
		{
			base.GetText(0).SetUIActive(visible);
		}

		// Token: 0x0603A1D2 RID: 238034 RVA: 0x00EB554F File Offset: 0x00EB374F
		public void SetDescVisible(bool visible)
		{
			base.GetText(3).SetUIActive(visible);
		}

		// Token: 0x0603A1D3 RID: 238035 RVA: 0x00EB555E File Offset: 0x00EB375E
		public void SetDescBgVisible(bool visible)
		{
			base.GetText(5).SetUIActive(visible);
		}

		// Token: 0x0603A1D4 RID: 238036 RVA: 0x00EB556D File Offset: 0x00EB376D
		public void SetDesc(string text)
		{
			base.GetText(3).SetText(text, true);
		}

		// Token: 0x0603A1D5 RID: 238037 RVA: 0x00EB557D File Offset: 0x00EB377D
		public void SetDescBg(string text)
		{
			base.GetText(5).SetText(text, true);
		}

		// Token: 0x0603A1D6 RID: 238038 RVA: 0x00EB558D File Offset: 0x00EB378D
		public void SetWeaponAttribute(IWeaponForgingData data)
		{
			this.WeaponAttributeComponent.RefreshTips(data);
		}

		// Token: 0x04020F62 RID: 135010
		[Nullable(2)]
		private WeaponAttributeView WeaponAttributeComponent;

		// Token: 0x04020F63 RID: 135011
		[Nullable(2)]
		public Action ChangeRoleClickDelegate;

		// Token: 0x0200B968 RID: 47464
		[NullableContext(0)]
		private class ESvInfoComponents
		{
			// Token: 0x0403943B RID: 234555
			public const int TxtType = 0;

			// Token: 0x0403943C RID: 234556
			public const int WeaponView = 1;

			// Token: 0x0403943D RID: 234557
			public const int Desc = 3;

			// Token: 0x0403943E RID: 234558
			public const int Line = 4;

			// Token: 0x0403943F RID: 234559
			public const int DescBg = 5;

			// Token: 0x04039440 RID: 234560
			public const int InventoryView = 6;
		}
	}
}
