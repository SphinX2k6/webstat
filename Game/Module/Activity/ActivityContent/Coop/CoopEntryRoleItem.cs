using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Coop
{
	// Token: 0x02006995 RID: 27029
	[NullableContext(2)]
	[Nullable(0)]
	public class CoopEntryRoleItem : UiPanelBase
	{
		// Token: 0x060430CD RID: 274637 RVA: 0x01137F31 File Offset: 0x01136131
		[NullableContext(1)]
		public CoopEntryRoleItem(CoopActivityData activityData)
		{
			this.ActivityData = activityData;
		}

		// Token: 0x060430CE RID: 274638 RVA: 0x01137F40 File Offset: 0x01136140
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUITexture)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIText)),
				new ValueTuple<int, Type>(7, typeof(UUIText)),
				new ValueTuple<int, Type>(8, typeof(UUISprite)),
				new ValueTuple<int, Type>(9, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(this.OnClickBtn))
			};
		}

		// Token: 0x060430CF RID: 274639 RVA: 0x01138058 File Offset: 0x01136258
		protected override void OnStart()
		{
			UUIButtonComponent button = base.GetButton(0);
			button.OnPointEnterCallBack.Bind(new Action(this.OnPointerEnter));
			button.OnPointExitCallBack.Bind(new Action(this.OnPointerExit));
		}

		// Token: 0x060430D0 RID: 274640 RVA: 0x0113808E File Offset: 0x0113628E
		protected override void OnBeforeDestroy()
		{
			UUIButtonComponent button = base.GetButton(0);
			button.OnPointEnterCallBack.Unbind();
			button.OnPointExitCallBack.Unbind();
		}

		// Token: 0x060430D1 RID: 274641 RVA: 0x011380AC File Offset: 0x011362AC
		[NullableContext(1)]
		public void Refresh(CoopRoleData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			CoopRole? coopRoleConfigByRoleId = ConfigBase<CoopConfig>.Instance.GetCoopRoleConfigByRoleId(data.RoleId);
			base.SetTextureByPath(data.IconPath, base.GetTexture(2), null, null);
			if (((coopRoleConfigByRoleId != null) ? coopRoleConfigByRoleId.GetValueOrDefault().RoleName : null) != null)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), coopRoleConfigByRoleId.Value.RoleName, Array.Empty<object>());
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), "Coop_Role_Number", new <>z__ReadOnlyArray<object>(new object[]
			{
				data.CurRoleLevel,
				data.MaxCoopLevel
			}));
			base.GetItem(1).SetUIActive(data.IsUnLock);
			base.GetItem(5).SetUIActive(data.IsUnLock);
			base.GetItem(4).SetUIActive(!data.IsUnLock);
			base.GetItem(3).SetUIActive(data.IsMaxLevel);
			bool flag = this.ActivityData.IsRoleHasRedDot(data.RoleId);
			base.GetSprite(8).SetUIActive(data.IsMaxLevel && !flag);
			base.GetItem(9).SetUIActive(flag);
		}

		// Token: 0x060430D2 RID: 274642 RVA: 0x011381F3 File Offset: 0x011363F3
		private void OnClickBtn()
		{
			Action<CoopRoleData> selectCallback = this.SelectCallback;
			if (selectCallback == null)
			{
				return;
			}
			selectCallback(this.Data);
		}

		// Token: 0x060430D3 RID: 274643 RVA: 0x0113820B File Offset: 0x0113640B
		private void OnPointerEnter()
		{
			CoopRoleData data = this.Data;
			if (data == null || !data.IsUnLock)
			{
				return;
			}
			Action<CoopRoleData> pointerEnterCallback = this.PointerEnterCallback;
			if (pointerEnterCallback == null)
			{
				return;
			}
			pointerEnterCallback(this.Data);
		}

		// Token: 0x060430D4 RID: 274644 RVA: 0x0113823B File Offset: 0x0113643B
		private void OnPointerExit()
		{
			Action pointerExitCallback = this.PointerExitCallback;
			if (pointerExitCallback == null)
			{
				return;
			}
			pointerExitCallback();
		}

		// Token: 0x0402559B RID: 152987
		private CoopRoleData Data;

		// Token: 0x0402559C RID: 152988
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<CoopRoleData> SelectCallback;

		// Token: 0x0402559D RID: 152989
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<CoopRoleData> PointerEnterCallback;

		// Token: 0x0402559E RID: 152990
		public Action PointerExitCallback;

		// Token: 0x0402559F RID: 152991
		private readonly CoopActivityData ActivityData;
	}
}
