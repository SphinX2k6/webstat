using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RhythmShip.View
{
	// Token: 0x020064E3 RID: 25827
	[NullableContext(1)]
	[Nullable(0)]
	public class RhythmShipChoseRoleView : UiViewBase
	{
		// Token: 0x06040B15 RID: 264981 RVA: 0x01096386 File Offset: 0x01094586
		public RhythmShipChoseRoleView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06040B16 RID: 264982 RVA: 0x01096390 File Offset: 0x01094590
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIHorizontalLayout)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(4, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(3, new Action(this.OnClickConfirmBtn))
			};
		}

		// Token: 0x06040B17 RID: 264983 RVA: 0x0109643C File Offset: 0x0109463C
		protected override UniTask OnBeforeStartAsync()
		{
			RhythmShipChoseRoleView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RhythmShipChoseRoleView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06040B18 RID: 264984 RVA: 0x01096480 File Offset: 0x01094680
		protected override void OnStart()
		{
			RhythmShipData activityData = ModelBase<RhythmShipModel>.Instance.ActivityData;
			if (activityData == null)
			{
				return;
			}
			this.CurrentSelectRole = activityData.CurrentRole;
			this.RoleLayout = new GenericLayout<RhythmShipChoseRoleItem, int>(base.GetHorizontalLayout(1), new Func<RhythmShipChoseRoleItem>(this.InitRoleItem), null, false, true);
			List<int> data = ConfigBase<RhythmShipConfig>.Instance.GetRhythmRoleAll() ?? new List<int>();
			this.RoleLayout.RefreshByData(data, delegate
			{
				GenericLayout<RhythmShipChoseRoleItem, int> roleLayout = this.RoleLayout;
				foreach (RhythmShipChoseRoleItem rhythmShipChoseRoleItem in (((roleLayout != null) ? roleLayout.GetLayoutItemList() : null) ?? new List<RhythmShipChoseRoleItem>()))
				{
					rhythmShipChoseRoleItem.SetCurrentLevelSelectState(rhythmShipChoseRoleItem.RoleId == this.CurrentSelectRole);
				}
			}, true);
		}

		// Token: 0x06040B19 RID: 264985 RVA: 0x010964F6 File Offset: 0x010946F6
		private RhythmShipChoseRoleItem InitRoleItem()
		{
			return new RhythmShipChoseRoleItem
			{
				OnClickToggleCallBack = new Action<int, UUIExtendToggle>(this.OnClickRoleItem)
			};
		}

		// Token: 0x06040B1A RID: 264986 RVA: 0x0109650F File Offset: 0x0109470F
		[NullableContext(2)]
		private void OnClickRoleItem(int roleId, UUIExtendToggle toggle)
		{
			UUIExtendToggle currentSelectToggle = this.CurrentSelectToggle;
			if (currentSelectToggle != null)
			{
				currentSelectToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
			}
			this.CurrentSelectToggle = toggle;
			this.CurrentSelectRole = roleId;
		}

		// Token: 0x06040B1B RID: 264987 RVA: 0x01096538 File Offset: 0x01094738
		private void OnClickConfirmBtn()
		{
			if (this.CurrentSelectRole != 0)
			{
				int currentSelectRole = this.CurrentSelectRole;
				RhythmShipData activityData = ModelBase<RhythmShipModel>.Instance.ActivityData;
				int? num = (activityData != null) ? new int?(activityData.CurrentRole) : null;
				if (!(currentSelectRole == num.GetValueOrDefault() & num != null))
				{
					ControllerBase<RhythmShipController>.Instance.RhythmChangePartnerRoleRequest(this.CurrentSelectRole);
				}
			}
			base.CloseMe(null);
		}

		// Token: 0x06040B1C RID: 264988 RVA: 0x010965A4 File Offset: 0x010947A4
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (configParams[0] == "RoleItem")
			{
				int num = int.Parse(configParams[1]);
				if (num >= 0)
				{
					int num2 = num;
					GenericLayout<RhythmShipChoseRoleItem, int> roleLayout = this.RoleLayout;
					if (num2 < ((roleLayout != null) ? roleLayout.GetLayoutItemList().Count : 0))
					{
						GenericLayout<RhythmShipChoseRoleItem, int> roleLayout2 = this.RoleLayout;
						UUIItem uuiitem = (roleLayout2 != null) ? roleLayout2.GetItemByIndex(num) : null;
						if (uuiitem == null)
						{
							return null;
						}
						return new UUIItem[]
						{
							uuiitem,
							uuiitem
						};
					}
				}
			}
			return null;
		}

		// Token: 0x040243FB RID: 148475
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x040243FC RID: 148476
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<RhythmShipChoseRoleItem, int> RoleLayout;

		// Token: 0x040243FD RID: 148477
		[Nullable(2)]
		private UUIExtendToggle CurrentSelectToggle;

		// Token: 0x040243FE RID: 148478
		private int CurrentSelectRole;
	}
}
