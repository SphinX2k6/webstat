using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x020067D0 RID: 26576
	public class DockyardStatePanel : UiPanelBase
	{
		// Token: 0x060424C5 RID: 271557 RVA: 0x011016F8 File Offset: 0x010FF8F8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060424C6 RID: 271558 RVA: 0x011017C4 File Offset: 0x010FF9C4
		[NullableContext(1)]
		protected UniTask InitConsumeItem(int itemId, UUIItem item)
		{
			DockyardStatePanel.<InitConsumeItem>d__2 <InitConsumeItem>d__;
			<InitConsumeItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitConsumeItem>d__.itemId = itemId;
			<InitConsumeItem>d__.item = item;
			<InitConsumeItem>d__.<>1__state = -1;
			<InitConsumeItem>d__.<>t__builder.Start<DockyardStatePanel.<InitConsumeItem>d__2>(ref <InitConsumeItem>d__);
			return <InitConsumeItem>d__.<>t__builder.Task;
		}

		// Token: 0x060424C7 RID: 271559 RVA: 0x01101810 File Offset: 0x010FFA10
		protected void InitSkillText()
		{
			int unlockFishingTechCount = ModelBase<FishingModel>.Instance.UnlockFishingTechCount;
			int allFishingTechCount = ModelBase<FishingModel>.Instance.AllFishingTechCount;
			UUIText text = base.GetText(3);
			if (text == null)
			{
				return;
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(unlockFishingTechCount);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(allFishingTechCount);
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}

		// Token: 0x060424C8 RID: 271560 RVA: 0x01101874 File Offset: 0x010FFA74
		protected void InitSpeedText()
		{
			EntityHandle entityHandle = ModelBase<FishingModel>.Instance.GetShipData().GetEntityHandle();
			object obj;
			if (entityHandle == null)
			{
				obj = null;
			}
			else
			{
				WorldEntity entity = entityHandle.Entity;
				obj = ((entity != null) ? entity.GetComponent<VehicleMoveComponent>() : null);
			}
			object obj2 = obj;
			float? num;
			if (obj2 == null)
			{
				num = null;
			}
			else
			{
				UKuroVehicleMovementComponent vehicleMovement = obj2.VehicleMovement;
				num = ((vehicleMovement != null) ? new float?(vehicleMovement.MaxSpeed) : null);
			}
			float? num2 = num;
			float valueOrDefault = num2.GetValueOrDefault();
			UUIText text = base.GetText(4);
			if (text == null)
			{
				return;
			}
			text.SetText(valueOrDefault.ToString(), true);
		}

		// Token: 0x060424C9 RID: 271561 RVA: 0x011018F8 File Offset: 0x010FFAF8
		protected override UniTask OnBeforeStartAsync()
		{
			DockyardStatePanel.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<DockyardStatePanel.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0200C81B RID: 51227
		private class EComponentDefine
		{
			// Token: 0x0403D949 RID: 252233
			public const int CurrencyItem = 0;

			// Token: 0x0403D94A RID: 252234
			public const int BombItem = 1;

			// Token: 0x0403D94B RID: 252235
			public const int BaitItem = 2;

			// Token: 0x0403D94C RID: 252236
			public const int SkillText = 3;

			// Token: 0x0403D94D RID: 252237
			public const int SpeedText = 4;
		}
	}
}
