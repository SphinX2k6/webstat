using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060C9 RID: 24777
	internal class SpecialEnergyBarKeLaiTaUltra : SpecialEnergyBarBase
	{
		// Token: 0x0603E934 RID: 256308 RVA: 0x01002434 File Offset: 0x01000634
		protected unsafe override void OnRegisterComponent()
		{
			int num = 18;
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
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
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
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603E935 RID: 256309 RVA: 0x010026B8 File Offset: 0x010008B8
		protected override UniTask OnBeforeStartAsync()
		{
			SpecialEnergyBarKeLaiTaUltra.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SpecialEnergyBarKeLaiTaUltra.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603E936 RID: 256310 RVA: 0x010026FC File Offset: 0x010008FC
		protected override void OnStart()
		{
			for (int i = 0; i < 4; i++)
			{
				this.TexBgItemList.Add(base.GetItem(1 + i));
				this.TexItemList.Add(base.GetItem(5 + i));
				base.InitTweenAnim(11 + i);
			}
			base.InitTweenAnim(15);
			this.RefreshNum(-1, true);
		}

		// Token: 0x0603E937 RID: 256311 RVA: 0x01002757 File Offset: 0x01000957
		protected override void AddEvents()
		{
			base.AddEvents();
			base.ListenForTagCountChanged(SpecialEnergyBarKeLaiTaUltra.NumTagId, new BaseTagComponent.TTagChangedCallback(this.OnNumTagCountChange));
		}

		// Token: 0x0603E938 RID: 256312 RVA: 0x01002776 File Offset: 0x01000976
		protected override void OnBeforeDestroy()
		{
			this.SetPlayEndAnim(false);
			base.OnBeforeDestroy();
		}

		// Token: 0x0603E939 RID: 256313 RVA: 0x01002785 File Offset: 0x01000985
		private void OnNumTagCountChange(int count, int tagId, int exactTagId, int oldCount)
		{
			this.RefreshNum(count, false);
		}

		// Token: 0x0603E93A RID: 256314 RVA: 0x01002790 File Offset: 0x01000990
		private void RefreshNum(int num = -1, bool isStart = false)
		{
			int num2 = num;
			if (num2 < 0)
			{
				BaseTagComponent tagComponent = this.TagComponent;
				num2 = ((tagComponent != null) ? tagComponent.GetTagCount(SpecialEnergyBarKeLaiTaUltra.NumTagId) : 0);
			}
			num2 = 4 - num2;
			if (num2 != this.CurNum || isStart)
			{
				bool enable = num2 >= 4;
				if (isStart)
				{
					for (int i = 0; i < 4; i++)
					{
						bool flag = i < num2;
						this.TexBgItemList[i].SetUIActive(!flag);
						this.TexItemList[i].SetUIActive(flag);
					}
				}
				else if (num2 < this.CurNum)
				{
					for (int j = 0; j < 4; j++)
					{
						base.StopTweenAnim(11 + j);
					}
					base.PlayTweenAnim(17);
					for (int k = 0; k < 4; k++)
					{
						bool flag2 = k < num2;
						this.TexBgItemList[k].SetUIActive(!flag2);
						this.TexItemList[k].SetUIActive(flag2);
					}
				}
				else
				{
					for (int l = this.CurNum; l < num2; l++)
					{
						base.PlayTweenAnim(11 + l);
					}
				}
				this.CurNum = num2;
				SpecialEnergyBarKeyItem keyItem = this.KeyItem;
				if (keyItem == null)
				{
					return;
				}
				keyItem.RefreshKeyEnable(enable, isStart);
			}
		}

		// Token: 0x0603E93B RID: 256315 RVA: 0x010028C3 File Offset: 0x01000AC3
		protected override bool GetKeyEnable()
		{
			return this.CurNum >= 4;
		}

		// Token: 0x0603E93C RID: 256316 RVA: 0x010028D4 File Offset: 0x01000AD4
		public override void Tick(float delta)
		{
			base.Tick(delta);
			if (this.Buff != null)
			{
				CharacterBuffComponent buffComponent = this.BuffComponent;
				if (((buffComponent != null) ? buffComponent.GetBuffByHandle(this.BuffHandle) : null) != null)
				{
					goto IL_2F;
				}
			}
			this.RefreshBuff();
			IL_2F:
			if (this.Buff != null)
			{
				this.SetPlayEndAnim(this.Buff.GetRemainDuration() < this.Config.ExtraFloatParams[0]);
			}
		}

		// Token: 0x0603E93D RID: 256317 RVA: 0x0100293C File Offset: 0x01000B3C
		private void RefreshBuff()
		{
			SpecialEnergyBarInfo config = this.Config;
			bool flag;
			if (config == null)
			{
				flag = false;
			}
			else
			{
				long buffId = config.BuffId;
				flag = true;
			}
			if (flag)
			{
				CharacterBuffComponent buffComponent = this.BuffComponent;
				this.Buff = ((buffComponent != null) ? buffComponent.GetBuffById(this.Config.BuffId) : null);
				IActiveBuff buff = this.Buff;
				this.BuffHandle = ((buff != null) ? buff.Handle : 0);
				return;
			}
			this.Buff = null;
			this.BuffHandle = 0;
		}

		// Token: 0x0603E93E RID: 256318 RVA: 0x010029A9 File Offset: 0x01000BA9
		private void SetPlayEndAnim(bool isPlay)
		{
			if (isPlay != this.IsPlayEndAnim)
			{
				this.IsPlayEndAnim = isPlay;
				if (isPlay)
				{
					base.PlayTweenAnim(15);
					return;
				}
				base.StopTweenAnim(15);
				UUIItem item = base.GetItem(16);
				if (item == null)
				{
					return;
				}
				item.SetAlpha(1f);
			}
		}

		// Token: 0x0402315D RID: 143709
		private const int NUM = 4;

		// Token: 0x0402315E RID: 143710
		[StaticVariableRuleIgnore]
		private static readonly int NumTagId = GameplayTagDefine.EGameplayTagId["角色.R2T1KamolaMd10011.被动.大招普攻记层"];

		// Token: 0x0402315F RID: 143711
		private int CurNum;

		// Token: 0x04023160 RID: 143712
		[Nullable(1)]
		private readonly List<UUIItem> TexBgItemList = new List<UUIItem>();

		// Token: 0x04023161 RID: 143713
		[Nullable(1)]
		private readonly List<UUIItem> TexItemList = new List<UUIItem>();

		// Token: 0x04023162 RID: 143714
		[Nullable(2)]
		private IActiveBuff Buff;

		// Token: 0x04023163 RID: 143715
		private int BuffHandle;

		// Token: 0x04023164 RID: 143716
		private bool IsPlayEndAnim;

		// Token: 0x0200C204 RID: 49668
		private enum EChildType
		{
			// Token: 0x0403BC68 RID: 244840
			KeyContainerItem,
			// Token: 0x0403BC69 RID: 244841
			TexBgItem1,
			// Token: 0x0403BC6A RID: 244842
			TexBgItem2,
			// Token: 0x0403BC6B RID: 244843
			TexBgItem3,
			// Token: 0x0403BC6C RID: 244844
			TexBgItem4,
			// Token: 0x0403BC6D RID: 244845
			TexItem1,
			// Token: 0x0403BC6E RID: 244846
			TexItem2,
			// Token: 0x0403BC6F RID: 244847
			TexItem3,
			// Token: 0x0403BC70 RID: 244848
			TexItem4,
			// Token: 0x0403BC71 RID: 244849
			LightItem1,
			// Token: 0x0403BC72 RID: 244850
			LightItem2,
			// Token: 0x0403BC73 RID: 244851
			AniCharge1,
			// Token: 0x0403BC74 RID: 244852
			AniCharge2,
			// Token: 0x0403BC75 RID: 244853
			AniCharge3,
			// Token: 0x0403BC76 RID: 244854
			AniCharge4,
			// Token: 0x0403BC77 RID: 244855
			AniEnd,
			// Token: 0x0403BC78 RID: 244856
			BarItem,
			// Token: 0x0403BC79 RID: 244857
			AnimReset
		}
	}
}
