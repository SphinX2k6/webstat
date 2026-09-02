using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.TotalTopUp
{
	// Token: 0x02006276 RID: 25206
	[NullableContext(1)]
	[Nullable(0)]
	public class TotalTopUpPickRoleRolePanel : UiPanelBase
	{
		// Token: 0x0603F7CC RID: 260044 RVA: 0x01046DE8 File Offset: 0x01044FE8
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIText)),
				new ValueTuple<int, Type>(4, typeof(UUISprite)),
				new ValueTuple<int, Type>(5, typeof(UUIText)),
				new ValueTuple<int, Type>(6, typeof(UUIItem))
			};
		}

		// Token: 0x0603F7CD RID: 260045 RVA: 0x01046E9C File Offset: 0x0104509C
		protected override UniTask OnBeforeStartAsync()
		{
			TotalTopUpPickRoleRolePanel.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TotalTopUpPickRoleRolePanel.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603F7CE RID: 260046 RVA: 0x01046EE0 File Offset: 0x010450E0
		public void Refresh(TotalTopUpPickRoleViewModel viewModel)
		{
			if (viewModel.CurrentRoleId <= 0)
			{
				return;
			}
			this.CurrentRoleId = viewModel.CurrentRoleId;
			this.PreviewRoleCallback = new Action(viewModel.PreviewAllRoles);
			this.RefreshRoleSpineItem(viewModel.CurrentRoleId);
			RoleDescribeComponent descComponent = this.DescComponent;
			if (descComponent != null)
			{
				descComponent.Update(viewModel.CurrentRoleId, false);
			}
			int currentRoleChainNum = viewModel.CurrentRoleChainNum;
			UUIItem item = base.GetItem(6);
			if (item != null)
			{
				item.SetUIActive(!viewModel.CurrentRoleOwned);
			}
			UUIItem item2 = base.GetItem(2);
			if (item2 != null)
			{
				item2.SetUIActive(viewModel.CurrentRoleOwned);
			}
			this.ApplyFullChainChangeColor(viewModel.CurrentIsFullChain);
			UUIText text = base.GetText(5);
			if (text == null)
			{
				return;
			}
			text.SetText(currentRoleChainNum.ToString(), true);
		}

		// Token: 0x0603F7CF RID: 260047 RVA: 0x01046F9C File Offset: 0x0104519C
		private UniTask RefreshRoleSpineItem(int roleId)
		{
			TotalTopUpPickRoleRolePanel.<RefreshRoleSpineItem>d__7 <RefreshRoleSpineItem>d__;
			<RefreshRoleSpineItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshRoleSpineItem>d__.<>4__this = this;
			<RefreshRoleSpineItem>d__.roleId = roleId;
			<RefreshRoleSpineItem>d__.<>1__state = -1;
			<RefreshRoleSpineItem>d__.<>t__builder.Start<TotalTopUpPickRoleRolePanel.<RefreshRoleSpineItem>d__7>(ref <RefreshRoleSpineItem>d__);
			return <RefreshRoleSpineItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603F7D0 RID: 260048 RVA: 0x01046FE8 File Offset: 0x010451E8
		private void ShowCurrentRole(int currentRoleId)
		{
			foreach (KeyValuePair<int, SpineRoleGachaPoolItem> keyValuePair in this.SpineItemMap)
			{
				int key = keyValuePair.Key;
				SpineRoleGachaPoolItem value = keyValuePair.Value;
				bool flag = key == currentRoleId;
				value.SetUiActive(flag);
				if (flag)
				{
					value.RefreshAnimation();
				}
			}
		}

		// Token: 0x0603F7D1 RID: 260049 RVA: 0x01047058 File Offset: 0x01045258
		private void ApplyFullChainChangeColor(bool isChange)
		{
			UUIText text = base.GetText(3);
			if (text != null)
			{
				UUIItem uuiitem = text;
				FColor? fcolor = new FColor?(text.changeColor);
				uuiitem.SetChangeColor(isChange, fcolor);
			}
			UUISprite sprite = base.GetSprite(4);
			if (sprite != null)
			{
				UUIItem uuiitem2 = sprite;
				FColor? fcolor = new FColor?(sprite.changeColor);
				uuiitem2.SetChangeColor(isChange, fcolor);
			}
			UUIText text2 = base.GetText(5);
			if (text2 != null)
			{
				UUIItem uuiitem3 = text2;
				FColor? fcolor = new FColor?(text2.changeColor);
				uuiitem3.SetChangeColor(isChange, fcolor);
			}
		}

		// Token: 0x04023A36 RID: 145974
		private readonly Dictionary<int, SpineRoleGachaPoolItem> SpineItemMap = new Dictionary<int, SpineRoleGachaPoolItem>();

		// Token: 0x04023A37 RID: 145975
		[Nullable(2)]
		private RoleDescribeComponent DescComponent;

		// Token: 0x04023A38 RID: 145976
		private int CurrentRoleId;

		// Token: 0x04023A39 RID: 145977
		[Nullable(2)]
		private Action PreviewRoleCallback;
	}
}
