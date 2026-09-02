using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MultiMotor
{
	// Token: 0x02006665 RID: 26213
	public class MultiMotorSettlementPlayerChampionItem : MultiMotorSettlementPlayerItem
	{
		// Token: 0x06041759 RID: 268121 RVA: 0x010CD128 File Offset: 0x010CB328
		protected unsafe override void OnRegisterComponent()
		{
			int num = 10;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnClickAddFriendBtn));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0604175A RID: 268122 RVA: 0x010CD2DC File Offset: 0x010CB4DC
		protected override void RefreshTime(int time, bool isFinish)
		{
			if (time <= 0 || !isFinish)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), "MultiMotorNotFinished", Array.Empty<object>());
				return;
			}
			string remainTimeDataFormat = Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat5((double)time * Singleton<TimeUtil>.Instance.Millisecond);
			base.GetText(3).SetText(remainTimeDataFormat, true);
		}

		// Token: 0x0604175B RID: 268123 RVA: 0x010CD334 File Offset: 0x010CB534
		protected override void RefreshRoleTexture(int skinId)
		{
			MotorOnlineRoleSkin? motorOnlineRoleSkinBySkinId = ConfigBase<MultiMotorConfig>.Instance.GetMotorOnlineRoleSkinBySkinId(skinId);
			if (motorOnlineRoleSkinBySkinId == null)
			{
				return;
			}
			base.SetTextureByPath(motorOnlineRoleSkinBySkinId.Value.RoleStand, base.GetTexture(0), null, null);
		}

		// Token: 0x0604175C RID: 268124 RVA: 0x010CD37D File Offset: 0x010CB57D
		[NullableContext(1)]
		protected override void RefreshChampionInfo(OnlineMotorSettleInfo data)
		{
			this.RefreshChampionCount(data.ChampionExtra.FirstCount);
		}

		// Token: 0x0604175D RID: 268125 RVA: 0x010CD390 File Offset: 0x010CB590
		private void RefreshChampionCount(int count)
		{
			base.GetText(9).SetText(count.ToString(), true);
		}

		// Token: 0x0200C68D RID: 50829
		private class EChampionComponents
		{
			// Token: 0x0403D22D RID: 250413
			public const int RoleTexture = 0;

			// Token: 0x0403D22E RID: 250414
			public const int TagText = 1;

			// Token: 0x0403D22F RID: 250415
			public const int Tag2Text = 2;

			// Token: 0x0403D230 RID: 250416
			public const int TimeText = 3;

			// Token: 0x0403D231 RID: 250417
			public const int OnlineNumberSprite = 4;

			// Token: 0x0403D232 RID: 250418
			public const int PlayerNameText = 5;

			// Token: 0x0403D233 RID: 250419
			public const int AddFriendBtn = 6;

			// Token: 0x0403D234 RID: 250420
			public const int HaveApplyItem = 7;

			// Token: 0x0403D235 RID: 250421
			public const int TagTextItem = 8;

			// Token: 0x0403D236 RID: 250422
			public const int ChampionCountText = 9;
		}
	}
}
