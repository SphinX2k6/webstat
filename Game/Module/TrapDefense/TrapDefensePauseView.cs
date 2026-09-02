using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E6A RID: 20074
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefensePauseView : UiViewBase
	{
		// Token: 0x06033E0F RID: 212495 RVA: 0x00CFA90A File Offset: 0x00CF8B0A
		public TrapDefensePauseView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06033E10 RID: 212496 RVA: 0x00CFA914 File Offset: 0x00CF8B14
		protected unsafe override void OnRegisterComponent()
		{
			int num = 10;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickClose));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickSetting));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06033E11 RID: 212497 RVA: 0x00CFAAE8 File Offset: 0x00CF8CE8
		protected override UniTask OnBeforeStartAsync()
		{
			TrapDefensePauseView.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TrapDefensePauseView.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06033E12 RID: 212498 RVA: 0x00CFAB2C File Offset: 0x00CF8D2C
		protected override void OnStart()
		{
			this.Layout = new GenericLayout<TrapDefenseResultInfoItem, ITrapDefensePauseInfo>(base.GetHorizontalLayout(2), new Func<TrapDefenseResultInfoItem>(this.CreateItem), base.GetItem(3).GetOwner() as AUIBaseActor, false, true);
			UUIText text = base.GetText(4);
			if (text != null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
				defaultInterpolatedStringHandler.AppendFormatted<int>(0);
				text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			}
			List<ITrapDefensePauseInfo> list = new List<ITrapDefensePauseInfo>();
			list.Add(new TrapDefensePauseInfo
			{
				Type = ETrapDefensePauseInfoType.Health
			});
			list.Add(new TrapDefensePauseInfo
			{
				Type = ETrapDefensePauseInfoType.BatchCur
			});
			this.Layout.RefreshByData(list, null, true);
			bool needStarWhenPause = ModelBase<TrapDefenseModel>.Instance.GetCurInstToLevelData().Config.NeedStarWhenPause;
			UUIItem item = base.GetItem(9);
			if (item != null)
			{
				item.SetUIActive(needStarWhenPause);
			}
			if (needStarWhenPause)
			{
				ControllerBase<TrapDefenseController>.Instance.RequestTrapDefenseCurChallengeInfo().ContinueWith(delegate(int task)
				{
					UUIText text2 = base.GetText(4);
					if (text2 == null)
					{
						return;
					}
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler2 = new DefaultInterpolatedStringHandler(0, 1);
					defaultInterpolatedStringHandler2.AppendFormatted<int>(task);
					text2.SetText(defaultInterpolatedStringHandler2.ToStringAndClear(), true);
				});
			}
		}

		// Token: 0x06033E13 RID: 212499 RVA: 0x00CFAC15 File Offset: 0x00CF8E15
		protected override void OnBeforeDestroy()
		{
			this.BtnBuff = null;
			this.BtnMonster = null;
			this.BtnSave = null;
			this.BtnEnd = null;
		}

		// Token: 0x06033E14 RID: 212500 RVA: 0x00CFAC33 File Offset: 0x00CF8E33
		private void OnClickClose()
		{
			base.CloseMe(null);
		}

		// Token: 0x06033E15 RID: 212501 RVA: 0x00CFAC3C File Offset: 0x00CF8E3C
		private void OnClickSetting()
		{
			ModelBase<TrapDefenseModel>.Instance.OpenViewKeySetting();
		}

		// Token: 0x06033E16 RID: 212502 RVA: 0x00CFAC48 File Offset: 0x00CF8E48
		private void OnClickBuff()
		{
			if (!ModelBase<TrapDefenseModel>.Instance.GetCurInstIsRogue())
			{
				return;
			}
			ModelBase<TrapDefenseModel>.Instance.OpenViewBdSum(null, null, null);
		}

		// Token: 0x06033E17 RID: 212503 RVA: 0x00CFAC88 File Offset: 0x00CF8E88
		private void OnClickMonsterInfo()
		{
			ModelBase<TrapDefenseModel>.Instance.OpenViewMonster(null, new ETrapDefenseMonsterTabType?(ETrapDefenseMonsterTabType.MonsterWave), null);
		}

		// Token: 0x06033E18 RID: 212504 RVA: 0x00CFACB7 File Offset: 0x00CF8EB7
		private void OnClickSaveAndLeave()
		{
			if (!ModelBase<TrapDefenseModel>.Instance.GetCurInstToLevelData().Config.IsCanSave)
			{
				return;
			}
			ModelBase<TrapDefenseModel>.Instance.NeedOpenMainView = true;
			ControllerBase<TrapDefenseController>.Instance.RequestTrapDefenseChallengeQuit(false);
		}

		// Token: 0x06033E19 RID: 212505 RVA: 0x00CFACE7 File Offset: 0x00CF8EE7
		private void OnClickEndAndLeave()
		{
			ControllerBase<TrapDefenseController>.Instance.RequestTrapDefenseChallengeQuit(true).ContinueWith(delegate(bool task)
			{
				if (task)
				{
					base.CloseMe(null);
				}
			});
		}

		// Token: 0x06033E1A RID: 212506 RVA: 0x00CFAD06 File Offset: 0x00CF8F06
		private TrapDefenseResultInfoItem CreateItem()
		{
			return new TrapDefenseResultInfoItem();
		}

		// Token: 0x0401E01A RID: 122906
		protected GenericLayout<TrapDefenseResultInfoItem, ITrapDefensePauseInfo> Layout;

		// Token: 0x0401E01B RID: 122907
		protected TrapDefenseResultInfoBtn BtnBuff;

		// Token: 0x0401E01C RID: 122908
		protected TrapDefenseResultInfoBtn BtnMonster;

		// Token: 0x0401E01D RID: 122909
		protected TrapDefenseResultInfoBtn BtnSave;

		// Token: 0x0401E01E RID: 122910
		protected TrapDefenseResultInfoBtn BtnEnd;
	}
}
