using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060F8 RID: 24824
	[NullableContext(1)]
	[Nullable(0)]
	public class SpecialEnergyBarMorph : SpecialEnergyBarBase
	{
		// Token: 0x0603EB84 RID: 256900 RVA: 0x0100E95C File Offset: 0x0100CB5C
		public override UniTask InitByPathAsync(UUIItem parentItem, string prefabPath)
		{
			SpecialEnergyBarMorph.<InitByPathAsync>d__15 <InitByPathAsync>d__;
			<InitByPathAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitByPathAsync>d__.<>4__this = this;
			<InitByPathAsync>d__.parentItem = parentItem;
			<InitByPathAsync>d__.<>1__state = -1;
			<InitByPathAsync>d__.<>t__builder.Start<SpecialEnergyBarMorph.<InitByPathAsync>d__15>(ref <InitByPathAsync>d__);
			return <InitByPathAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603EB85 RID: 256901 RVA: 0x0100E9A8 File Offset: 0x0100CBA8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603EB86 RID: 256902 RVA: 0x0100EAB8 File Offset: 0x0100CCB8
		protected override UniTask OnBeforeStartAsync()
		{
			SpecialEnergyBarMorph.<OnBeforeStartAsync>d__17 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SpecialEnergyBarMorph.<OnBeforeStartAsync>d__17>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603EB87 RID: 256903 RVA: 0x0100EAFC File Offset: 0x0100CCFC
		protected override void OnInitData()
		{
			base.OnInitData();
			if (this.Config == null)
			{
				return;
			}
			this.KeyEnableNiagaraIndex = this.Config.KeyEnableNiagaraIndex;
			this.NeedExtraEffectOnKeyEnable = (this.KeyEnableNiagaraIndex >= 0);
			List<float> extraFloatParams = this.Config.ExtraFloatParams;
			int count = extraFloatParams.Count;
			if (count > 1)
			{
				this.ReplaceFullEffectIndex = (int)extraFloatParams[1];
			}
			if (count > 2)
			{
				this.ReplaceStartEffectIndex = (int)extraFloatParams[2];
			}
		}

		// Token: 0x0603EB88 RID: 256904 RVA: 0x0100EB70 File Offset: 0x0100CD70
		protected override void OnStart()
		{
			UUITexture[] iconTextureList = new UUITexture[]
			{
				base.GetTexture(0)
			};
			this.IconHandle.Init(iconTextureList, base.GetItem(6));
			SpecialEnergyBarInfo config = this.Config;
			if (!string.IsNullOrEmpty((config != null) ? config.EnableIconPath : null))
			{
				this.NeedRefreshIconOnKeyEnable = true;
			}
			else
			{
				this.NeedRefreshIconOnKeyEnable = false;
				SpecialEnergyBaIconHandle iconHandle = this.IconHandle;
				SpecialEnergyBarInfo config2 = this.Config;
				iconHandle.SetIcon((!string.IsNullOrEmpty((config2 != null) ? config2.IconPath : null)) ? this.Config.IconPath : null);
			}
			this.FrontIconHandle.Init(new UUITexture[]
			{
				base.GetTexture(5)
			}, null);
			SpecialEnergyBaIconHandle frontIconHandle = this.FrontIconHandle;
			SpecialEnergyBarInfo config3 = this.Config;
			frontIconHandle.SetIcon((!string.IsNullOrEmpty((config3 != null) ? config3.FrontIconPath : null)) ? this.Config.FrontIconPath : null);
			if (this.StartEffectFinishTime == 0.0)
			{
				base.GetUiNiagara(2).SetUIActive(false);
			}
			this.RefreshBuff();
			if (this.NeedExtraEffectOnKeyEnable)
			{
				UNiagaraSystem valueOrDefault = this.NiagaraList.GetValueOrDefault(this.KeyEnableNiagaraIndex);
				if (valueOrDefault != null)
				{
					base.GetUiNiagara(3).SetNiagaraSystem(valueOrDefault);
					SpecialEnergyBarInfo config4 = this.Config;
					string text = (config4 != null) ? config4.OtherEffectColorList.GetValueOrDefault(this.KeyEnableNiagaraIndex) : null;
					if (!string.IsNullOrEmpty(text))
					{
						FColor fcolor = FColor.FromHex(text);
						FLinearColor value = new FLinearColor(ref fcolor);
						base.GetUiNiagara(3).SetNiagaraVarLinearColor("Color", value);
					}
				}
				base.GetUiNiagara(3).SetUIActive(false);
			}
			if (this.ReplaceFullEffectIndex >= 0)
			{
				UNiagaraSystem valueOrDefault2 = this.NiagaraList.GetValueOrDefault(this.ReplaceFullEffectIndex);
				if (valueOrDefault2 != null && this.BarItem != null)
				{
					this.BarItem.ReplaceFullEffect(valueOrDefault2);
					SpecialEnergyBarSlot specialEnergyBarSlot = this.BarItem as SpecialEnergyBarSlot;
					if (specialEnergyBarSlot != null)
					{
						specialEnergyBarSlot.UpdateFullEffectOffsetBySlotWidth();
					}
				}
			}
			if (this.ReplaceStartEffectIndex >= 0)
			{
				UNiagaraSystem valueOrDefault3 = this.NiagaraList.GetValueOrDefault(this.ReplaceStartEffectIndex);
				if (valueOrDefault3 != null)
				{
					base.GetUiNiagara(2).SetNiagaraSystem(valueOrDefault3);
				}
			}
			this.RefreshBarPercent(true);
		}

		// Token: 0x0603EB89 RID: 256905 RVA: 0x0100ED70 File Offset: 0x0100CF70
		protected void RefreshBuff()
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

		// Token: 0x0603EB8A RID: 256906 RVA: 0x0100EDE0 File Offset: 0x0100CFE0
		public override void OnChangeVisibleByTagChange(bool visible)
		{
			if (!visible)
			{
				this.Buff = null;
				this.BuffHandle = 0;
				this.IconHandle.PlayEndAnim(false);
				return;
			}
			this.RefreshBuff();
			if (!base.IsShowOrShowing)
			{
				return;
			}
			base.GetUiNiagara(2).SetUIActive(true);
			this.StartEffectFinishTime = 500.0 + Singleton<Time>.Instance.Now;
		}

		// Token: 0x0603EB8B RID: 256907 RVA: 0x0100EE44 File Offset: 0x0100D044
		protected UniTask InitBarItem()
		{
			SpecialEnergyBarMorph.<InitBarItem>d__22 <InitBarItem>d__;
			<InitBarItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitBarItem>d__.<>4__this = this;
			<InitBarItem>d__.<>1__state = -1;
			<InitBarItem>d__.<>t__builder.Start<SpecialEnergyBarMorph.<InitBarItem>d__22>(ref <InitBarItem>d__);
			return <InitBarItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603EB8C RID: 256908 RVA: 0x0100EE87 File Offset: 0x0100D087
		[NullableContext(2)]
		protected virtual Type GetSpecialEnergyBarClass()
		{
			return SpecialEnergyBarMorph.SpecialEnergyBarClassList.GetValueOrDefault(this.Config.PrefabType);
		}

		// Token: 0x0603EB8D RID: 256909 RVA: 0x0100EE9E File Offset: 0x0100D09E
		protected override void OnBeforeDestroy()
		{
			base.OnBeforeDestroy();
			this.IconHandle.OnBeforeDestroy();
			this.FrontIconHandle.OnBeforeDestroy();
		}

		// Token: 0x0603EB8E RID: 256910 RVA: 0x0100EEBC File Offset: 0x0100D0BC
		protected void RefreshBarPercent(bool isStart = false)
		{
			bool keyEnable = this.GetKeyEnable();
			this.RefreshIcon(keyEnable);
			this.RefreshExtraEffectOnKeyEnable(keyEnable);
			SpecialEnergyBarKeyItem keyItem = this.KeyItem;
			if (keyItem == null)
			{
				return;
			}
			keyItem.RefreshKeyEnable(keyEnable, isStart);
		}

		// Token: 0x0603EB8F RID: 256911 RVA: 0x0100EEF0 File Offset: 0x0100D0F0
		protected void RefreshIcon(bool bEnable)
		{
			if (!this.NeedRefreshIconOnKeyEnable)
			{
				return;
			}
			string icon = this.Config.IconPath;
			if (bEnable && !string.IsNullOrEmpty(this.Config.EnableIconPath))
			{
				icon = this.Config.EnableIconPath;
			}
			this.IconHandle.SetIcon(icon);
		}

		// Token: 0x0603EB90 RID: 256912 RVA: 0x0100EF3F File Offset: 0x0100D13F
		protected void RefreshExtraEffectOnKeyEnable(bool bEnable)
		{
			if (!this.NeedExtraEffectOnKeyEnable)
			{
				return;
			}
			if (this.ExtraEffectActive != bEnable)
			{
				this.ExtraEffectActive = bEnable;
				base.GetUiNiagara(3).SetUIActive(bEnable);
			}
		}

		// Token: 0x0603EB91 RID: 256913 RVA: 0x0100EF67 File Offset: 0x0100D167
		protected override void OnBarPercentChanged()
		{
			this.RefreshBarPercent(false);
		}

		// Token: 0x0603EB92 RID: 256914 RVA: 0x0100EF70 File Offset: 0x0100D170
		protected override void OnKeyEnableChanged()
		{
			this.RefreshBarPercent(false);
		}

		// Token: 0x0603EB93 RID: 256915 RVA: 0x0100EF7C File Offset: 0x0100D17C
		public override void Tick(float delta)
		{
			base.Tick(delta);
			SpecialEnergyBarBase barItem = this.BarItem;
			if (barItem != null)
			{
				barItem.Tick(delta);
			}
			if (this.StartEffectFinishTime > 0.0 && this.StartEffectFinishTime <= Singleton<Time>.Instance.Now)
			{
				base.GetUiNiagara(2).SetUIActive(false);
				this.StartEffectFinishTime = 0.0;
			}
			if (this.Buff != null)
			{
				CharacterBuffComponent buffComponent = this.BuffComponent;
				if (((buffComponent != null) ? buffComponent.GetBuffByHandle(this.BuffHandle) : null) != null)
				{
					goto IL_80;
				}
			}
			this.RefreshBuff();
			IL_80:
			if (this.Buff != null)
			{
				this.IconHandle.PlayEndAnim(this.Buff.GetRemainDuration() < this.Config.ExtraFloatParams[0]);
			}
		}

		// Token: 0x0603EB94 RID: 256916 RVA: 0x0100F03A File Offset: 0x0100D23A
		public override void ReplaceFullEffect(UNiagaraSystem niagara)
		{
			this.BarItem.ReplaceFullEffect(niagara);
		}

		// Token: 0x040232C2 RID: 144066
		[StaticVariableRuleIgnore]
		private static readonly Type[] SpecialEnergyBarClassList = new Type[]
		{
			null,
			null,
			null,
			typeof(SpecialEnergyBarPoint),
			typeof(SpecialEnergyBarSlot),
			null,
			null,
			null,
			null,
			typeof(SpecialEnergyBarPointGraduate)
		};

		// Token: 0x040232C3 RID: 144067
		private const double EFFECT_DURATION = 500.0;

		// Token: 0x040232C4 RID: 144068
		private readonly SpecialEnergyBaIconHandle IconHandle = new SpecialEnergyBaIconHandle();

		// Token: 0x040232C5 RID: 144069
		private readonly SpecialEnergyBaIconHandle FrontIconHandle = new SpecialEnergyBaIconHandle();

		// Token: 0x040232C6 RID: 144070
		[Nullable(2)]
		protected SpecialEnergyBarBase BarItem;

		// Token: 0x040232C7 RID: 144071
		private double StartEffectFinishTime;

		// Token: 0x040232C8 RID: 144072
		[Nullable(2)]
		private IActiveBuff Buff;

		// Token: 0x040232C9 RID: 144073
		private int BuffHandle;

		// Token: 0x040232CA RID: 144074
		private bool NeedRefreshIconOnKeyEnable;

		// Token: 0x040232CB RID: 144075
		private bool ExtraEffectActive;

		// Token: 0x040232CC RID: 144076
		protected bool NeedExtraEffectOnKeyEnable;

		// Token: 0x040232CD RID: 144077
		protected int KeyEnableNiagaraIndex = -1;

		// Token: 0x040232CE RID: 144078
		protected int ReplaceFullEffectIndex = -1;

		// Token: 0x040232CF RID: 144079
		protected int ReplaceStartEffectIndex = -1;

		// Token: 0x0200C27B RID: 49787
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403BF51 RID: 245585
			IconTexture,
			// Token: 0x0403BF52 RID: 245586
			KeyContainerItem,
			// Token: 0x0403BF53 RID: 245587
			StartEffect,
			// Token: 0x0403BF54 RID: 245588
			ExtraEffect,
			// Token: 0x0403BF55 RID: 245589
			SlotContainerItem,
			// Token: 0x0403BF56 RID: 245590
			FrontIconTexture,
			// Token: 0x0403BF57 RID: 245591
			AnimItem
		}
	}
}
