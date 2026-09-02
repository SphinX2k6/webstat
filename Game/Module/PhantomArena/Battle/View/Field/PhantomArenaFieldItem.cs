using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena.Battle.Canvas;
using CSharpScript.Game.Module.PhantomArena.Battle.Model;
using CSharpScript.Game.Module.PhantomArena.Battle.SkillInteract;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Battle.View.Field
{
	// Token: 0x020055C6 RID: 21958
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaFieldItem : UiPanelBase, IAreaCanvas, ISkillInteractMainInterface
	{
		// Token: 0x06037EE0 RID: 229088 RVA: 0x00E2B5CC File Offset: 0x00E297CC
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUITexture)),
				new ValueTuple<int, Type>(3, typeof(UUITexture)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUITexture)),
				new ValueTuple<int, Type>(6, typeof(UUITexture)),
				new ValueTuple<int, Type>(7, typeof(UUISprite)),
				new ValueTuple<int, Type>(8, typeof(UUIItem)),
				new ValueTuple<int, Type>(9, typeof(UUIText)),
				new ValueTuple<int, Type>(10, typeof(UUIItem)),
				new ValueTuple<int, Type>(11, typeof(UUITexture)),
				new ValueTuple<int, Type>(12, typeof(UUITexture)),
				new ValueTuple<int, Type>(13, typeof(UUINiagara)),
				new ValueTuple<int, Type>(14, typeof(UUINiagara)),
				new ValueTuple<int, Type>(15, typeof(UUINiagara)),
				new ValueTuple<int, Type>(16, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(this.OnInteractClick))
			};
		}

		// Token: 0x06037EE1 RID: 229089 RVA: 0x00E2B788 File Offset: 0x00E29988
		protected override UniTask OnBeforeStartAsync()
		{
			PhantomArenaFieldItem.<OnBeforeStartAsync>d__12 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PhantomArenaFieldItem.<OnBeforeStartAsync>d__12>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06037EE2 RID: 229090 RVA: 0x00E2B7CC File Offset: 0x00E299CC
		protected override void OnStart()
		{
			this.Sequence = new UiSequencePlayer(this.RootItem);
			this.Sequence.BindOnEndSequenceEvent(new Action<string>(this.OnSequenceEndEvent));
			this.SwitchActiveState(false);
			UUIButtonComponent button = base.GetButton(0);
			button.OnPointEnterCallBack.Bind(new Action(this.OnPointerEnter));
			button.OnPointExitCallBack.Bind(new Action(this.OnPointerExit));
		}

		// Token: 0x06037EE3 RID: 229091 RVA: 0x00E2B83C File Offset: 0x00E29A3C
		protected override void OnBeforeDestroy()
		{
			this.Sequence.Clear();
		}

		// Token: 0x06037EE4 RID: 229092 RVA: 0x00E2B849 File Offset: 0x00E29A49
		private void OnInteractClick()
		{
			Action<PhantomArenaFieldData, PhantomArenaFieldItem> interactClickCallback = this.InteractClickCallback;
			if (interactClickCallback == null)
			{
				return;
			}
			interactClickCallback(this.FieldData, this);
		}

		// Token: 0x06037EE5 RID: 229093 RVA: 0x00E2B862 File Offset: 0x00E29A62
		private void OnPointerEnter()
		{
			Action<PhantomArenaFieldData, UUIItem> pointerEnterCallback = this.PointerEnterCallback;
			if (pointerEnterCallback == null)
			{
				return;
			}
			pointerEnterCallback(this.FieldData, base.GetItem(16));
		}

		// Token: 0x06037EE6 RID: 229094 RVA: 0x00E2B882 File Offset: 0x00E29A82
		private void OnPointerExit()
		{
			Action pointerExitCallback = this.PointerExitCallback;
			if (pointerExitCallback == null)
			{
				return;
			}
			pointerExitCallback();
		}

		// Token: 0x06037EE7 RID: 229095 RVA: 0x00E2B894 File Offset: 0x00E29A94
		private void OnSequenceEndEvent(string sequenceName)
		{
			if (!(sequenceName == "CdClose"))
			{
				if (sequenceName == "CdStart")
				{
					base.GetTexture(3).SetUIActive(false);
				}
				return;
			}
			UUISprite sprite = base.GetSprite(7);
			if (sprite == null)
			{
				return;
			}
			sprite.SetUIActive(false);
		}

		// Token: 0x06037EE8 RID: 229096 RVA: 0x00E2B8D0 File Offset: 0x00E29AD0
		private void RefreshCount()
		{
			if (this.FieldData.HasCountSkill)
			{
				base.GetItem(8).SetUIActive(true);
				base.GetText(9).SetText(this.FieldData.CurEffectCount.ToString() + "/" + this.FieldData.MaxEffectCount.ToString(), true);
				if (this.FieldData.CurEffectCount == this.FieldData.MaxEffectCount)
				{
					this.Sequence.PlaySequencePurely("BuffNumFull", false, false);
				}
				else if (this.LastEffectCount < this.FieldData.CurEffectCount)
				{
					this.Sequence.PlaySequencePurely("BuffNumAdd", false, false);
				}
				this.LastEffectCount = this.FieldData.CurEffectCount;
				return;
			}
			base.GetItem(8).SetUIActive(false);
		}

		// Token: 0x06037EE9 RID: 229097 RVA: 0x00E2B9A8 File Offset: 0x00E29BA8
		private void RefreshCdState()
		{
			if (this.IsLastInSkillCd && !this.FieldData.IsInSkillCd)
			{
				UUISprite sprite = base.GetSprite(3);
				if (sprite != null)
				{
					sprite.SetUIActive(true);
				}
				this.Sequence.PlaySequence("CdClose", false, null);
			}
			else if (!this.IsLastInSkillCd && this.FieldData.IsInSkillCd)
			{
				UUISprite sprite2 = base.GetSprite(7);
				if (sprite2 != null)
				{
					sprite2.SetUIActive(true);
				}
				this.Sequence.PlaySequence("CdStart", false, null);
			}
			this.IsLastInSkillCd = this.FieldData.IsInSkillCd;
		}

		// Token: 0x06037EEA RID: 229098 RVA: 0x00E2BA4C File Offset: 0x00E29C4C
		private void RefreshInteractState()
		{
			if (!this.IsLastCanInteract && this.FieldData.IsCanInteractive)
			{
				this.Sequence.PlaySequence("Activate", false, null);
				this.SwitchActiveState(true);
			}
			else if (this.IsLastCanInteract && !this.FieldData.IsCanInteractive)
			{
				this.SwitchActiveState(false);
			}
			this.IsLastCanInteract = this.FieldData.IsCanInteractive;
		}

		// Token: 0x06037EEB RID: 229099 RVA: 0x00E2BAC0 File Offset: 0x00E29CC0
		private void RefreshTexState()
		{
			if (this.FieldData.CardData != null && !StringUtils.IsBlank(this.FieldData.FieldButtonColor))
			{
				FColor color = FColor.FromHex(this.FieldData.FieldButtonColor);
				base.GetTexture(11).SetColor(color);
				base.GetTexture(12).SetColor(color);
			}
		}

		// Token: 0x06037EEC RID: 229100 RVA: 0x00E2BB1C File Offset: 0x00E29D1C
		private void RefreshNiagaraState()
		{
			if (this.FieldData.CardData != null)
			{
				if (!StringUtils.IsBlank(this.FieldData.FieldNorColor))
				{
					UUINiagara uiNiagara = base.GetUiNiagara(13);
					FColor fcolor = FColor.FromHex(this.FieldData.FieldNorColor);
					FLinearColor value = new FLinearColor(ref fcolor);
					uiNiagara.SetNiagaraVarLinearColor("Base_Color", value);
				}
				if (!StringUtils.IsBlank(this.FieldData.FieldActivateColor))
				{
					UUIItem uiNiagara2 = base.GetUiNiagara(15);
					FColor color = FColor.FromHex(this.FieldData.FieldActivateColor);
					uiNiagara2.SetColor(color);
				}
			}
		}

		// Token: 0x06037EED RID: 229101 RVA: 0x00E2BBA8 File Offset: 0x00E29DA8
		private UniTask RefreshIcon()
		{
			PhantomArenaFieldItem.<RefreshIcon>d__24 <RefreshIcon>d__;
			<RefreshIcon>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshIcon>d__.<>4__this = this;
			<RefreshIcon>d__.<>1__state = -1;
			<RefreshIcon>d__.<>t__builder.Start<PhantomArenaFieldItem.<RefreshIcon>d__24>(ref <RefreshIcon>d__);
			return <RefreshIcon>d__.<>t__builder.Task;
		}

		// Token: 0x06037EEE RID: 229102 RVA: 0x00E2BBEC File Offset: 0x00E29DEC
		private UniTask RefreshNiagaraSystemState()
		{
			PhantomArenaFieldItem.<RefreshNiagaraSystemState>d__25 <RefreshNiagaraSystemState>d__;
			<RefreshNiagaraSystemState>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshNiagaraSystemState>d__.<>4__this = this;
			<RefreshNiagaraSystemState>d__.<>1__state = -1;
			<RefreshNiagaraSystemState>d__.<>t__builder.Start<PhantomArenaFieldItem.<RefreshNiagaraSystemState>d__25>(ref <RefreshNiagaraSystemState>d__);
			return <RefreshNiagaraSystemState>d__.<>t__builder.Task;
		}

		// Token: 0x06037EEF RID: 229103 RVA: 0x00E2BC30 File Offset: 0x00E29E30
		private UniTask RefreshLockState()
		{
			PhantomArenaFieldItem.<RefreshLockState>d__26 <RefreshLockState>d__;
			<RefreshLockState>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshLockState>d__.<>4__this = this;
			<RefreshLockState>d__.<>1__state = -1;
			<RefreshLockState>d__.<>t__builder.Start<PhantomArenaFieldItem.<RefreshLockState>d__26>(ref <RefreshLockState>d__);
			return <RefreshLockState>d__.<>t__builder.Task;
		}

		// Token: 0x06037EF0 RID: 229104 RVA: 0x00E2BC73 File Offset: 0x00E29E73
		private void SwitchActiveState(bool isActive)
		{
			base.GetItem(4).SetUIActive(isActive);
			base.GetItem(1).SetUIActive(!isActive);
		}

		// Token: 0x06037EF1 RID: 229105 RVA: 0x00E2BC94 File Offset: 0x00E29E94
		public UniTask Refresh(PhantomArenaFieldData filedData)
		{
			PhantomArenaFieldItem.<Refresh>d__28 <Refresh>d__;
			<Refresh>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Refresh>d__.<>4__this = this;
			<Refresh>d__.filedData = filedData;
			<Refresh>d__.<>1__state = -1;
			<Refresh>d__.<>t__builder.Start<PhantomArenaFieldItem.<Refresh>d__28>(ref <Refresh>d__);
			return <Refresh>d__.<>t__builder.Task;
		}

		// Token: 0x06037EF2 RID: 229106 RVA: 0x00E2BCE0 File Offset: 0x00E29EE0
		public UniTask RefreshSelf()
		{
			PhantomArenaFieldItem.<RefreshSelf>d__29 <RefreshSelf>d__;
			<RefreshSelf>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshSelf>d__.<>4__this = this;
			<RefreshSelf>d__.<>1__state = -1;
			<RefreshSelf>d__.<>t__builder.Start<PhantomArenaFieldItem.<RefreshSelf>d__29>(ref <RefreshSelf>d__);
			return <RefreshSelf>d__.<>t__builder.Task;
		}

		// Token: 0x06037EF3 RID: 229107 RVA: 0x00E2BD24 File Offset: 0x00E29F24
		public void UseSkill()
		{
			this.Sequence.PlaySequence("Use", false, null);
		}

		// Token: 0x06037EF4 RID: 229108 RVA: 0x00E2BD4B File Offset: 0x00E29F4B
		public void ResetSkill()
		{
			this.Sequence.PlaySequencePurely("UnUse", false, false);
		}

		// Token: 0x06037EF5 RID: 229109 RVA: 0x00E2BD5F File Offset: 0x00E29F5F
		public void SetInteractClickCallback(Action<PhantomArenaFieldData, PhantomArenaFieldItem> callback)
		{
			this.InteractClickCallback = callback;
		}

		// Token: 0x06037EF6 RID: 229110 RVA: 0x00E2BD68 File Offset: 0x00E29F68
		public void SetFinishSkillInteractCallback(Action<PhantomArenaFieldData> callback)
		{
			this.FinishSkillInteractClickCallback = callback;
		}

		// Token: 0x06037EF7 RID: 229111 RVA: 0x00E2BD71 File Offset: 0x00E29F71
		public void SetPointerEnterCallback(Action<PhantomArenaFieldData, UUIItem> callback)
		{
			this.PointerEnterCallback = callback;
		}

		// Token: 0x06037EF8 RID: 229112 RVA: 0x00E2BD7A File Offset: 0x00E29F7A
		public void SetPointerExitCallback(Action callback)
		{
			this.PointerExitCallback = callback;
		}

		// Token: 0x06037EF9 RID: 229113 RVA: 0x00E2BD84 File Offset: 0x00E29F84
		public string GetFieldDesc()
		{
			return ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(this.FieldData.CardConfigId).FieldTriggerDesc;
		}

		// Token: 0x06037EFA RID: 229114 RVA: 0x00E2BDAE File Offset: 0x00E29FAE
		public void SetFieldItemActive(bool active)
		{
			if (this.FieldData.CardData != null && active)
			{
				this.SetActive(true);
				return;
			}
			this.SetActive(false);
		}

		// Token: 0x06037EFB RID: 229115 RVA: 0x00E2BDD4 File Offset: 0x00E29FD4
		public bool CheckCanvasSortOrder(List<EPhantomArenaInteractTag> tagList, ISkillTriggerInfo skillTriggerInfo)
		{
			if (!tagList.Contains(EPhantomArenaInteractTag.OwnFiled))
			{
				return false;
			}
			int? dataId = skillTriggerInfo.DataId;
			int cardConfigId = this.FieldData.CardConfigId;
			return dataId.GetValueOrDefault() == cardConfigId & dataId != null;
		}

		// Token: 0x06037EFC RID: 229116 RVA: 0x00E2BE16 File Offset: 0x00E2A016
		public void HandleSortOrder()
		{
			this.RootItem.GetRenderCanvas().SetSortOrderNew(2, true);
		}

		// Token: 0x06037EFD RID: 229117 RVA: 0x00E2BE2A File Offset: 0x00E2A02A
		public void CancelSortOrder()
		{
			this.RootItem.GetRenderCanvas().SetSortOrderNew(0, true);
		}

		// Token: 0x06037EFE RID: 229118 RVA: 0x00E2BE40 File Offset: 0x00E2A040
		public UniTask StartSkillInteract()
		{
			return default(UniTask);
		}

		// Token: 0x06037EFF RID: 229119 RVA: 0x00E2BE56 File Offset: 0x00E2A056
		public ISkillTriggerInfo GetData()
		{
			return ModelBase<PhantomArenaBattleModel>.Instance.BuffEffectData.CardSkillTriggerInfo;
		}

		// Token: 0x06037F00 RID: 229120 RVA: 0x00E2BE67 File Offset: 0x00E2A067
		public void FinishSkillInteract()
		{
			Action<PhantomArenaFieldData> finishSkillInteractClickCallback = this.FinishSkillInteractClickCallback;
			if (finishSkillInteractClickCallback == null)
			{
				return;
			}
			finishSkillInteractClickCallback(this.FieldData);
		}

		// Token: 0x06037F01 RID: 229121 RVA: 0x00E2BE7F File Offset: 0x00E2A07F
		public void CancelSkillInteract()
		{
			this.Sequence.PlaySequencePurely("UnUse", false, false);
		}

		// Token: 0x06037F02 RID: 229122 RVA: 0x00E2BE93 File Offset: 0x00E2A093
		[NullableContext(2)]
		public void ReceiveUiInteract(ISkillInteractMainUiInteract uiInteract)
		{
		}

		// Token: 0x0401FFE8 RID: 131048
		public PhantomArenaFieldData FieldData;

		// Token: 0x0401FFE9 RID: 131049
		protected PhantomArenaSealItem SealItem;

		// Token: 0x0401FFEA RID: 131050
		protected Action<PhantomArenaFieldData, PhantomArenaFieldItem> InteractClickCallback;

		// Token: 0x0401FFEB RID: 131051
		protected Action<PhantomArenaFieldData> FinishSkillInteractClickCallback;

		// Token: 0x0401FFEC RID: 131052
		protected Action<PhantomArenaFieldData, UUIItem> PointerEnterCallback;

		// Token: 0x0401FFED RID: 131053
		protected Action PointerExitCallback;

		// Token: 0x0401FFEE RID: 131054
		protected UiSequencePlayer Sequence;

		// Token: 0x0401FFEF RID: 131055
		protected bool IsLastInSkillCd;

		// Token: 0x0401FFF0 RID: 131056
		protected bool IsLastCanInteract;

		// Token: 0x0401FFF1 RID: 131057
		protected int LastEffectCount;

		// Token: 0x0200B5AE RID: 46510
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x04038378 RID: 230264
			public const int InteractButton = 0;

			// Token: 0x04038379 RID: 230265
			public const int NormalItem = 1;

			// Token: 0x0403837A RID: 230266
			public const int NormalRing = 2;

			// Token: 0x0403837B RID: 230267
			public const int NormalIcon = 3;

			// Token: 0x0403837C RID: 230268
			public const int ActiveItem = 4;

			// Token: 0x0403837D RID: 230269
			public const int ActiveRing = 5;

			// Token: 0x0403837E RID: 230270
			public const int ActiveIcon = 6;

			// Token: 0x0403837F RID: 230271
			public const int CdIcon = 7;

			// Token: 0x04038380 RID: 230272
			public const int CountItem = 8;

			// Token: 0x04038381 RID: 230273
			public const int CountText = 9;

			// Token: 0x04038382 RID: 230274
			public const int SealItem = 10;

			// Token: 0x04038383 RID: 230275
			public const int NormalTex = 11;

			// Token: 0x04038384 RID: 230276
			public const int ActivateTex = 12;

			// Token: 0x04038385 RID: 230277
			public const int NormalNiagara = 13;

			// Token: 0x04038386 RID: 230278
			public const int ElementNiagara = 14;

			// Token: 0x04038387 RID: 230279
			public const int ActivateNiagara = 15;

			// Token: 0x04038388 RID: 230280
			public const int ContentItem = 16;
		}
	}
}
