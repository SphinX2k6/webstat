using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020017C8 RID: 6088
[NullableContext(2)]
[Nullable(0)]
public class BuffTargetRoleItem : UiPanelBase
{
	// Token: 0x0600AC9A RID: 44186 RVA: 0x002E06D2 File Offset: 0x002DE8D2
	[NullableContext(1)]
	public void Initialize(AActor rootActor)
	{
		base.CreateThenShowByActor(rootActor, null);
	}

	// Token: 0x0600AC9B RID: 44187 RVA: 0x002E06DC File Offset: 0x002DE8DC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUISprite)),
			new ValueTuple<int, Type>(4, typeof(UUISprite)),
			new ValueTuple<int, Type>(5, typeof(UUISprite)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(9, typeof(UUINiagara))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(7, new Action(this.OnClickedSelectedRoleButton))
		};
	}

	// Token: 0x0600AC9C RID: 44188 RVA: 0x002E07F4 File Offset: 0x002DE9F4
	private void OnClickedSelectedRoleButton()
	{
		if (this.OnClickedCallback != null)
		{
			this.OnClickedCallback(this);
		}
	}

	// Token: 0x0600AC9D RID: 44189 RVA: 0x002E080C File Offset: 0x002DEA0C
	protected override void OnStart()
	{
		this.ItemGrid = new MediumItemGrid();
		this.ItemGrid.Initialize(base.GetItem(0).GetOwner());
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		this.NiagaraBuffItem = base.GetUiNiagara(9);
		this.NiagaraBuffItem.SetUIActive(false);
	}

	// Token: 0x0600AC9E RID: 44190 RVA: 0x002E0866 File Offset: 0x002DEA66
	protected override void OnBeforeDestroy()
	{
		this.ItemGrid = null;
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.Clear();
		}
		this.ResetBuffTargetRoleItem();
		this.EndNiagaraBuff();
		this.NiagaraBuffItem = null;
	}

	// Token: 0x0600AC9F RID: 44191 RVA: 0x002E0893 File Offset: 0x002DEA93
	public void ResetBuffTargetRoleItem()
	{
		this.UseBuffItemRoleData = null;
		this.NiagaraBuffResourceFlag = false;
		this.RemoveEntityEvents();
	}

	// Token: 0x0600ACA0 RID: 44192 RVA: 0x002E08A9 File Offset: 0x002DEAA9
	public void Tick(float delta)
	{
		if (!this.IsPlayingAnimation)
		{
			return;
		}
		if (this.AnimationCurrentTime > 200f)
		{
			this.FinishUseItemAnimation();
			return;
		}
		this.RefreshAnimationValueBar();
		this.AnimationCurrentTime += delta;
	}

	// Token: 0x0600ACA1 RID: 44193 RVA: 0x002E08DC File Offset: 0x002DEADC
	[NullableContext(1)]
	public void RefreshBuffTargetRoleItem(UseBuffItemRoleData useBuffItemRoleData)
	{
		this.UseBuffItemRoleData = useBuffItemRoleData;
		int roleConfigId = useBuffItemRoleData.RoleConfigId;
		RoleInfo value = ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleConfigId).Value;
		int roleLevel = useBuffItemRoleData.RoleLevel;
		float num = (float)Math.Floor((double)useBuffItemRoleData.CurrentAttribute);
		float num2 = (float)Math.Floor((double)useBuffItemRoleData.MaxAttribute);
		CharacterMediumItemGrid parameters = new CharacterMediumItemGrid
		{
			ItemConfigId = new int?(roleConfigId),
			SkinId = value.SkinId,
			BottomTextId = "Text_LevelShow_Text",
			BottomTextParameter = new object[]
			{
				roleLevel
			},
			ElementId = new int?(value.ElementId)
		};
		this.ItemGrid.Apply<CharacterMediumItemGrid>(parameters);
		this.SetCurrentValueBarPercent(num / num2);
		this.SetValueText((int)num, (int)num2);
		this.SetPreviewValueBarVisible(false);
		this.SetAnimationValueBarVisible(false);
		this.SetAddValueTextVisible(false);
		this.SetSelected(false);
		this.SetNoneRole(false);
		this.AddEntityEvents();
	}

	// Token: 0x0600ACA2 RID: 44194 RVA: 0x002E09D7 File Offset: 0x002DEBD7
	public void RemoveRole()
	{
		this.SetNoneRole(true);
		this.RemoveEntityEvents();
		this.UseBuffItemRoleData = null;
	}

	// Token: 0x0600ACA3 RID: 44195 RVA: 0x002E09ED File Offset: 0x002DEBED
	private void AddEntityEvents()
	{
		if (this.UseBuffItemRoleData == null)
		{
			return;
		}
		this.UseBuffItemRoleData.Entity.GetComponent<BaseAttributeComponent>().AddListener(EAttributeType.Life, new Action<EAttributeType, float, float>(this.OnCharOnHealthChanged), "Life.BuffTargetRoleItem");
	}

	// Token: 0x0600ACA4 RID: 44196 RVA: 0x002E0A1F File Offset: 0x002DEC1F
	private void RemoveEntityEvents()
	{
		if (this.UseBuffItemRoleData == null)
		{
			return;
		}
		this.UseBuffItemRoleData.Entity.GetComponent<BaseAttributeComponent>().RemoveListener(EAttributeType.Life, new Action<EAttributeType, float, float>(this.OnCharOnHealthChanged));
	}

	// Token: 0x0600ACA5 RID: 44197 RVA: 0x002E0A50 File Offset: 0x002DEC50
	private void OnCharOnHealthChanged(EAttributeType attributeId, float newValue, float oldValue)
	{
		if (newValue == oldValue)
		{
			return;
		}
		if (this.UseBuffItemRoleData == null)
		{
			return;
		}
		float currentValue = this.UseBuffItemRoleData.Entity.GetComponent<BaseAttributeComponent>().GetCurrentValue(EAttributeType.LifeMax);
		this.UseBuffItemRoleData.SetCurrentAttribute(newValue);
		this.PlayPreviewBarAnimation(oldValue, newValue, currentValue);
	}

	// Token: 0x0600ACA6 RID: 44198 RVA: 0x002E0A98 File Offset: 0x002DEC98
	public void RefreshPreviewUseItem(float currentAttribute, float maxAttribute, float addAttribute)
	{
		float num = Math.Min(currentAttribute + addAttribute, maxAttribute);
		float num2 = Math.Min(addAttribute, maxAttribute - currentAttribute);
		this.SetCurrentValueBarPercent(currentAttribute / maxAttribute);
		this.SetPreviewValueBarPercent(num / maxAttribute);
		this.SetPreviewValueBarVisible(addAttribute > 0f);
		this.SetAddValueText((int)Math.Floor((double)num2));
		this.SetAddValueTextVisible(addAttribute > 0f);
		this.SetPreviewValueText((int)Math.Floor((double)num), (int)Math.Floor((double)maxAttribute));
	}

	// Token: 0x0600ACA7 RID: 44199 RVA: 0x002E0B10 File Offset: 0x002DED10
	public void ResetPreviewUseItem()
	{
		float currentAttribute = this.UseBuffItemRoleData.CurrentAttribute;
		float maxAttribute = this.UseBuffItemRoleData.MaxAttribute;
		this.SetPreviewValueBarVisible(false);
		this.SetAddValueTextVisible(false);
		this.SetValueText((int)currentAttribute, (int)maxAttribute);
	}

	// Token: 0x0600ACA8 RID: 44200 RVA: 0x002E0B50 File Offset: 0x002DED50
	public void SetCurrentValueBarPercent(float percent)
	{
		UUISprite sprite = base.GetSprite(4);
		UUIItem uuiitem = sprite;
		bool bUseChangeColor = percent <= 0.2f;
		FColor? fcolor = new FColor?(sprite.changeColor);
		uuiitem.SetChangeColor(bUseChangeColor, fcolor);
		sprite.SetFillAmount(percent);
	}

	// Token: 0x0600ACA9 RID: 44201 RVA: 0x002E0B8B File Offset: 0x002DED8B
	public void SetPreviewValueBarPercent(float percent)
	{
		base.GetSprite(5).SetFillAmount(percent);
	}

	// Token: 0x0600ACAA RID: 44202 RVA: 0x002E0B9A File Offset: 0x002DED9A
	public void SetPreviewValueBarVisible(bool bVisible)
	{
		base.GetSprite(5).SetUIActive(bVisible);
	}

	// Token: 0x0600ACAB RID: 44203 RVA: 0x002E0BA9 File Offset: 0x002DEDA9
	public void SetAnimationValueBarPercent(float percent)
	{
		base.GetSprite(3).SetFillAmount(percent);
	}

	// Token: 0x0600ACAC RID: 44204 RVA: 0x002E0BB8 File Offset: 0x002DEDB8
	private void SetAnimationColorState(float percent)
	{
		UUISprite sprite = base.GetSprite(3);
		UUIItem uuiitem = sprite;
		bool bUseChangeColor = percent <= 0.2f;
		FColor? fcolor = new FColor?(sprite.changeColor);
		uuiitem.SetChangeColor(bUseChangeColor, fcolor);
	}

	// Token: 0x0600ACAD RID: 44205 RVA: 0x002E0BEC File Offset: 0x002DEDEC
	public void SetAnimationValueBarVisible(bool bVisible)
	{
		base.GetSprite(3).SetUIActive(bVisible);
	}

	// Token: 0x0600ACAE RID: 44206 RVA: 0x002E0BFC File Offset: 0x002DEDFC
	public void SetAddValueText(int addValue)
	{
		UUIText text = base.GetText(1);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
		defaultInterpolatedStringHandler.AppendLiteral("+");
		defaultInterpolatedStringHandler.AppendFormatted<int>(addValue);
		text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
	}

	// Token: 0x0600ACAF RID: 44207 RVA: 0x002E0C3A File Offset: 0x002DEE3A
	private void SetAddValueTextVisible(bool bVisible)
	{
		base.GetText(1).SetUIActive(bVisible);
	}

	// Token: 0x0600ACB0 RID: 44208 RVA: 0x002E0C4C File Offset: 0x002DEE4C
	private void SetValueText(int currentValue, int maxValue)
	{
		UUIText text = base.GetText(2);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler;
		if (currentValue <= 0)
		{
			UUIText uuitext = text;
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(26, 2);
			defaultInterpolatedStringHandler.AppendLiteral("<color=#ff0000ff>");
			defaultInterpolatedStringHandler.AppendFormatted<double>(Math.Ceiling((double)currentValue));
			defaultInterpolatedStringHandler.AppendLiteral("</color>/");
			defaultInterpolatedStringHandler.AppendFormatted<double>(Math.Ceiling((double)maxValue));
			uuitext.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			return;
		}
		UUIText uuitext2 = text;
		defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
		defaultInterpolatedStringHandler.AppendFormatted<double>(Math.Ceiling((double)currentValue));
		defaultInterpolatedStringHandler.AppendLiteral("/");
		defaultInterpolatedStringHandler.AppendFormatted<double>(Math.Ceiling((double)maxValue));
		uuitext2.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
	}

	// Token: 0x0600ACB1 RID: 44209 RVA: 0x002E0CF4 File Offset: 0x002DEEF4
	public void SetPreviewValueText(int value, int maxValue)
	{
		UUIText text = base.GetText(2);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(26, 2);
		defaultInterpolatedStringHandler.AppendLiteral("<color=#00ff00ff>");
		defaultInterpolatedStringHandler.AppendFormatted<int>(value);
		defaultInterpolatedStringHandler.AppendLiteral("</color>/");
		defaultInterpolatedStringHandler.AppendFormatted<int>(maxValue);
		text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
	}

	// Token: 0x0600ACB2 RID: 44210 RVA: 0x002E0D48 File Offset: 0x002DEF48
	public void SetSelected(bool bSelected)
	{
		if (bSelected)
		{
			this.ItemGrid.SetSelected(true, false);
			this.LevelSequencePlayer.PlayLevelSequenceByName("Selected", false, null, false);
		}
		else
		{
			this.ResetPreviewUseItem();
			this.SetAnimationValueBarVisible(false);
			this.ItemGrid.SetSelected(false, false);
		}
		this.IsRoleSelected = bSelected;
	}

	// Token: 0x0600ACB3 RID: 44211 RVA: 0x002E0DA3 File Offset: 0x002DEFA3
	public bool IsSelected()
	{
		return this.IsRoleSelected;
	}

	// Token: 0x0600ACB4 RID: 44212 RVA: 0x002E0DAC File Offset: 0x002DEFAC
	public void SetNoneRole(bool bNone)
	{
		UUIItem item = base.GetItem(8);
		UUIItem item2 = base.GetItem(6);
		item.SetUIActive(bNone);
		item2.SetUIActive(!bNone);
	}

	// Token: 0x0600ACB5 RID: 44213 RVA: 0x002E0DD8 File Offset: 0x002DEFD8
	public UseBuffItemRoleData GetUseBuffItemRoleData()
	{
		return this.UseBuffItemRoleData;
	}

	// Token: 0x0600ACB6 RID: 44214 RVA: 0x002E0DE0 File Offset: 0x002DEFE0
	[NullableContext(1)]
	public void BindOnClickedBuffTargetRoleItem(Action<BuffTargetRoleItem> onClickedCallback)
	{
		this.OnClickedCallback = onClickedCallback;
	}

	// Token: 0x0600ACB7 RID: 44215 RVA: 0x002E0DEC File Offset: 0x002DEFEC
	private void StartNiagaraBuff()
	{
		Action startNiagaraAnimation = delegate()
		{
			this.NiagaraBuffItem.SetUIActive(true);
			this.NiagaraBuffItem.ActivateSystem(true);
		};
		if (!this.NiagaraBuffResourceFlag)
		{
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("Niagara_BuffTreat");
			base.SetNiagaraSystemByPath(resourcePath, this.NiagaraBuffItem, delegate(bool _)
			{
				this.NiagaraBuffResourceFlag = true;
				startNiagaraAnimation();
			});
			return;
		}
		startNiagaraAnimation();
	}

	// Token: 0x0600ACB8 RID: 44216 RVA: 0x002E0E55 File Offset: 0x002DF055
	private void EndNiagaraBuff()
	{
		this.NiagaraBuffItem.DeactivateSystem();
		this.NiagaraBuffItem.SetUIActive(false);
	}

	// Token: 0x0600ACB9 RID: 44217 RVA: 0x002E0E70 File Offset: 0x002DF070
	private void PlayPreviewBarAnimation(float currentAttribute, float targetAttribute, float maxAttribute)
	{
		if (currentAttribute == targetAttribute)
		{
			return;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Test;
		ELogAuthor author = ELogAuthor.YYZ;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(58, 3);
		defaultInterpolatedStringHandler.AppendLiteral("播放属性进度条动画，currentAttribute：");
		defaultInterpolatedStringHandler.AppendFormatted<float>(currentAttribute);
		defaultInterpolatedStringHandler.AppendLiteral(",targetAttribute:");
		defaultInterpolatedStringHandler.AppendFormatted<float>(targetAttribute);
		defaultInterpolatedStringHandler.AppendLiteral(",maxAttribute:");
		defaultInterpolatedStringHandler.AppendFormatted<float>(maxAttribute);
		instance.Info(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
		if (!this.IsPlayingAnimation)
		{
			this.AnimationCurrentAttribute = currentAttribute;
		}
		this.StartNiagaraBuff();
		this.AnimationTargetAttribute = targetAttribute;
		this.AnimationMaxAttribute = maxAttribute;
		this.AnimationCurrentTime = 0f;
		this.IsPlayingAnimation = true;
		this.SetAnimationValueBarVisible(true);
		this.SetAnimationColorState(this.AnimationCurrentAttribute / this.AnimationMaxAttribute);
		this.ResetPreviewUseItem();
		this.LevelSequencePlayer.PlayLevelSequenceByName("Reply", false, null, false);
	}

	// Token: 0x0600ACBA RID: 44218 RVA: 0x002E0F58 File Offset: 0x002DF158
	private void FinishUseItemAnimation()
	{
		this.IsPlayingAnimation = false;
		this.AnimationCurrentTime = -1f;
		float currentAttribute = this.UseBuffItemRoleData.CurrentAttribute;
		float maxAttribute = this.UseBuffItemRoleData.MaxAttribute;
		float addAttribute = this.UseBuffItemRoleData.GetAddAttribute();
		this.SetAnimationColorState(currentAttribute / maxAttribute);
		this.RefreshPreviewUseItem(currentAttribute, maxAttribute, addAttribute);
		this.SetAnimationValueBarVisible(false);
		if (this.OnUseItemAnimationFinishedCallback != null)
		{
			this.OnUseItemAnimationFinishedCallback();
		}
	}

	// Token: 0x0600ACBB RID: 44219 RVA: 0x002E0FC8 File Offset: 0x002DF1C8
	[NullableContext(1)]
	public void BindOnUseItemAnimationFinished(Action onUseItemAnimationFinishedCallback)
	{
		this.OnUseItemAnimationFinishedCallback = onUseItemAnimationFinishedCallback;
	}

	// Token: 0x0600ACBC RID: 44220 RVA: 0x002E0FD4 File Offset: 0x002DF1D4
	private void RefreshAnimationValueBar()
	{
		float alpha = Math.Min(this.AnimationCurrentTime / 200f, 1f);
		this.AnimationCurrentAttribute = Singleton<MathUtils>.Instance.Lerp(this.AnimationCurrentAttribute, this.AnimationTargetAttribute, alpha);
		this.SetAnimationValueBarPercent(this.AnimationCurrentAttribute / this.AnimationMaxAttribute);
	}

	// Token: 0x040051C4 RID: 20932
	private const int ANIMATION_LENGTH = 200;

	// Token: 0x040051C5 RID: 20933
	private const float LOW_HP_PERCENT = 0.2f;

	// Token: 0x040051C6 RID: 20934
	private UseBuffItemRoleData UseBuffItemRoleData;

	// Token: 0x040051C7 RID: 20935
	private float AnimationCurrentAttribute = -1f;

	// Token: 0x040051C8 RID: 20936
	private float AnimationTargetAttribute;

	// Token: 0x040051C9 RID: 20937
	private float AnimationCurrentTime;

	// Token: 0x040051CA RID: 20938
	private bool IsPlayingAnimation;

	// Token: 0x040051CB RID: 20939
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Action<BuffTargetRoleItem> OnClickedCallback;

	// Token: 0x040051CC RID: 20940
	private float AnimationMaxAttribute;

	// Token: 0x040051CD RID: 20941
	private Action OnUseItemAnimationFinishedCallback;

	// Token: 0x040051CE RID: 20942
	private MediumItemGrid ItemGrid;

	// Token: 0x040051CF RID: 20943
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x040051D0 RID: 20944
	private UUINiagara NiagaraBuffItem;

	// Token: 0x040051D1 RID: 20945
	private bool NiagaraBuffResourceFlag;

	// Token: 0x040051D2 RID: 20946
	private bool IsRoleSelected;

	// Token: 0x02007B56 RID: 31574
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x0402A2A6 RID: 172710
		ItemGridItem,
		// Token: 0x0402A2A7 RID: 172711
		AddValueText,
		// Token: 0x0402A2A8 RID: 172712
		CurrentValueText,
		// Token: 0x0402A2A9 RID: 172713
		AnimationValueBarSprite,
		// Token: 0x0402A2AA RID: 172714
		CurrentValueBarSprite,
		// Token: 0x0402A2AB RID: 172715
		PreviewValueBarSprite,
		// Token: 0x0402A2AC RID: 172716
		RoleDetailItem,
		// Token: 0x0402A2AD RID: 172717
		SelectedButton,
		// Token: 0x0402A2AE RID: 172718
		NoneRoleItem,
		// Token: 0x0402A2AF RID: 172719
		NiagaraBuff
	}
}
