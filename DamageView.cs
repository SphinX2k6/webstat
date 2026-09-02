using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001AB3 RID: 6835
[NullableContext(1)]
[Nullable(0)]
public class DamageView : UiPanelBase
{
	// Token: 0x0600C3FD RID: 50173 RVA: 0x0033B1DC File Offset: 0x003393DC
	public void Init()
	{
		AActor damageView = ControllerBase<BattleUiControl>.Instance.Pool.GetDamageView();
		base.CreateByActor(damageView, null);
	}

	// Token: 0x0600C3FE RID: 50174 RVA: 0x0033B204 File Offset: 0x00339404
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUINiagara)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIItem))
		};
	}

	// Token: 0x0600C3FF RID: 50175 RVA: 0x0033B328 File Offset: 0x00339528
	protected override void OnStart()
	{
		this.DamageNum = base.GetText(0);
		this.DamageText = base.GetText(2);
		this.FontSize = this.DamageNum.GetSize();
		this.TimeScale = 1f;
		this.CurTimeScale = 1f;
		if (Singleton<Info>.Instance.IsMobilePlatform())
		{
			this.RefreshFontSize();
		}
	}

	// Token: 0x0600C400 RID: 50176 RVA: 0x0033B388 File Offset: 0x00339588
	public void RefreshFontSize()
	{
		if (Singleton<Info>.Instance.IsMobilePlatform())
		{
			int num = (int)Math.Floor((double)(this.FontSize * 1.5f));
			this.DamageNum.SetFontSize((float)num);
			this.DamageText.SetFontSize((float)num);
			return;
		}
		this.DamageNum.SetFontSize(this.FontSize);
		this.DamageText.SetFontSize(this.FontSize);
	}

	// Token: 0x0600C401 RID: 50177 RVA: 0x0033B3F2 File Offset: 0x003395F2
	protected override bool DestroyOverride()
	{
		ControllerBase<BattleUiControl>.Instance.Pool.RecycleDamageView(this.RootActor);
		return true;
	}

	// Token: 0x0600C402 RID: 50178 RVA: 0x0033B40C File Offset: 0x0033960C
	public void InitializeData(float damage, global::Vector damageLocation, global::Vector baseLocation, DamageViewData damageViewData, bool bCritical = false, bool bCure = false, bool bOwnPlayerDamage = false, string damageText = "", int damageTextAreaId = 0, [Nullable(new byte[]
	{
		2,
		1
	})] List<DamageInfo> mergeDamageInfoList = null)
	{
		if (damageViewData == null)
		{
			return;
		}
		this.IsFollowPlayer = bOwnPlayerDamage;
		this.DamageViewData = damageViewData;
		this.DamageLocation.FromUeVector(damageLocation);
		this.BaseLocation.FromUeVector(baseLocation);
		this.DamageLocationUe = this.DamageLocation.ToUeVector(false);
		DamageTextArea? damageTextAreaById = Singleton<DamageUiManager>.Instance.GetDamageTextAreaById(damageTextAreaId);
		APlayerController characterController = Global.CharacterController;
		FVectorDouble fvectorDouble = this.DamageLocation.ToUeVector(false);
		FVector2D fvector2D = ULGUIBPLibrary.ConvertWorldPosToLGUIPos(characterController, fvectorDouble);
		float num;
		float num2;
		float num3;
		float num4;
		if (damageTextAreaById != null)
		{
			num = (float)damageTextAreaById.Value.MinDeviationX;
			num2 = (float)damageTextAreaById.Value.MaxDeviationX;
			num3 = (float)damageTextAreaById.Value.MinDeviationY;
			num4 = (float)damageTextAreaById.Value.MaxDeviationY;
		}
		else
		{
			num = damageViewData.MinRandomOffsetX;
			num2 = damageViewData.MaxRandomOffsetX;
			num3 = damageViewData.MinRandomOffsetY;
			num4 = damageViewData.MaxRandomOffsetY;
		}
		if (bCritical)
		{
			num *= 1f;
			num3 *= 1f;
			num2 *= 1f;
			num4 *= 1f;
		}
		this.RandomUiPosition.X = (double)Singleton<MathUtils>.Instance.GetRandomFloatNumber(num, num2);
		this.RandomUiPosition.Y = (double)Singleton<MathUtils>.Instance.GetRandomFloatNumber(num3, num4);
		this.SetDamageLocation(fvector2D.X + (float)this.RandomUiPosition.X, fvector2D.Y + (float)this.RandomUiPosition.Y);
		this.TextList.Clear();
		if (mergeDamageInfoList != null)
		{
			if (StringUtils.IsEmpty(damageText))
			{
				string text;
				if (!bCure)
				{
					text = damage.ToString();
				}
				else
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
					defaultInterpolatedStringHandler.AppendLiteral("+");
					defaultInterpolatedStringHandler.AppendFormatted<float>(damage);
					text = defaultInterpolatedStringHandler.ToStringAndClear();
				}
				string item = text;
				this.TextList.Add(item);
			}
			float num5 = 0f;
			int num6 = 1;
			foreach (DamageInfo damageInfo in mergeDamageInfoList)
			{
				if (StringUtils.IsEmpty(damageText))
				{
					damageInfo.Damage = (float)Math.Floor((double)Math.Abs(damageInfo.Damage));
					num6++;
					if (num6 < 10)
					{
						List<string> textList = this.TextList;
						string item2;
						if (!damageInfo.IsCure)
						{
							item2 = damageInfo.Damage.ToString();
						}
						else
						{
							DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
							defaultInterpolatedStringHandler.AppendLiteral("+");
							defaultInterpolatedStringHandler.AppendFormatted<float>(damageInfo.Damage);
							item2 = defaultInterpolatedStringHandler.ToStringAndClear();
						}
						textList.Add(item2);
					}
					else if (bCure)
					{
						num5 += damageInfo.Damage;
					}
					else
					{
						num5 -= damageInfo.Damage;
					}
				}
			}
			if (num5 > 0f)
			{
				List<string> textList2 = this.TextList;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
				defaultInterpolatedStringHandler.AppendLiteral("+");
				defaultInterpolatedStringHandler.AppendFormatted<float>(num5);
				textList2.Add(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			else if (num5 < 0f)
			{
				List<string> textList3 = this.TextList;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
				defaultInterpolatedStringHandler.AppendFormatted<float>(Math.Abs(num5));
				textList3.Add(defaultInterpolatedStringHandler.ToStringAndClear());
			}
		}
		if (this.TextList.Count > 0)
		{
			this.TextIndex = 0;
			this.PlayDamageViewAnim(bOwnPlayerDamage, false, false);
			this.RefreshCriticalNiagara(false);
			this.RefreshTextDisplay(this.TextList[0], false, false);
		}
		else
		{
			this.TextIndex = -1;
			bool flag = !StringUtils.IsEmpty(damageText);
			string text2 = this.FormatNumber(damage);
			string damageTextString = flag ? damageText : (bCure ? ("+" + text2) : text2.ToString());
			this.PlayDamageViewAnim(bOwnPlayerDamage, bCritical, flag);
			this.RefreshCriticalNiagara(bCritical);
			this.RefreshTextDisplay(damageTextString, bCritical, flag);
		}
		this.RefreshDepth();
		this.SetActive(true);
		this.DamageNum.SetAlpha(0f);
	}

	// Token: 0x0600C403 RID: 50179 RVA: 0x0033B804 File Offset: 0x00339A04
	private string FormatNumber(float num)
	{
		return Singleton<DamageUiManager>.Instance.FormatDamageNumber(num);
	}

	// Token: 0x0600C404 RID: 50180 RVA: 0x0033B811 File Offset: 0x00339A11
	public void ClearData()
	{
		this.DamageViewData = null;
		this.StopDamageViewAnim();
		this.SetActive(false);
		this.SetCriticalNiagaraVisible(false);
	}

	// Token: 0x0600C405 RID: 50181 RVA: 0x0033B830 File Offset: 0x00339A30
	private void PlayDamageViewAnim(bool bOwnPlayerDamage, bool bCritical, bool bCustomText)
	{
		this.AnimEndTime = 1200f;
		string sequencePath = this.DamageViewData.GetSequencePath(bOwnPlayerDamage, bCritical, bCustomText);
		int name;
		if (!this.DamageAnimMap.TryGetValue(sequencePath, out name))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Battle;
			ELogAuthor author = ELogAuthor.CFT;
			string message = "缺少伤害数字动画";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("sequencePath", sequencePath);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		TArray<UActorComponent> tarray = base.GetItem(name).GetOwner().K2_GetComponentsByClass(ULGUIPlayTweenComponent.StaticClass());
		this.Animations = new List<ULGUIPlayTweenComponent>();
		int num = tarray.Num();
		for (int i = 0; i < num; i++)
		{
			ULGUIPlayTweenComponent ulguiplayTweenComponent = tarray.Get(i) as ULGUIPlayTweenComponent;
			this.Animations.Add(ulguiplayTweenComponent);
			ulguiplayTweenComponent.Play();
		}
	}

	// Token: 0x0600C406 RID: 50182 RVA: 0x0033B8F0 File Offset: 0x00339AF0
	private void StopDamageViewAnim()
	{
		if (this.Animations == null)
		{
			return;
		}
		this.SetTimeScale(1f);
		foreach (ULGUIPlayTweenComponent ulguiplayTweenComponent in this.Animations)
		{
			ulguiplayTweenComponent.Stop();
		}
		this.Animations = null;
	}

	// Token: 0x0600C407 RID: 50183 RVA: 0x0033B95C File Offset: 0x00339B5C
	public void Tick(float delta)
	{
		if (this.RootItem == null)
		{
			return;
		}
		if (this.CriticalNiagara != null)
		{
			UUINiagara uiNiagara = base.GetUiNiagara(3);
			uiNiagara.SetNiagaraSystem(this.CriticalNiagara);
			uiNiagara.ActivateSystem(true);
			this.CriticalNiagara = null;
		}
		if (this.TimeScale == 1f)
		{
			this.AnimEndTime -= delta;
		}
		else if (this.AnimEndTime > 700f)
		{
			this.AnimEndTime -= delta;
		}
		else
		{
			this.AnimEndTime -= delta * this.TimeScale;
			this.UpdateCurTimeScale(this.TimeScale);
		}
		if (this.AnimEndTime <= 0f)
		{
			Singleton<DamageUiManager>.Instance.RemoveDamageView(this);
			return;
		}
		if (this.TextIndex != -1)
		{
			int num = (int)Math.Floor((double)((1200f - this.AnimEndTime) / 100f));
			if (this.TextIndex != num)
			{
				this.TextIndex = num;
				if (this.TextList.Count > num)
				{
					this.DamageNum.SetText(this.TextList[num], true);
				}
			}
		}
		if (!this.IsFollowPlayer)
		{
			this.RefreshDamageLocation();
			return;
		}
		this.RefreshPlayerDamageLocation();
	}

	// Token: 0x0600C408 RID: 50184 RVA: 0x0033BA7C File Offset: 0x00339C7C
	private void UpdateCurTimeScale(float timeScale)
	{
		if (this.CurTimeScale == timeScale)
		{
			return;
		}
		this.CurTimeScale = timeScale;
		if (this.Animations == null)
		{
			return;
		}
		foreach (ULGUIPlayTweenComponent ulguiplayTweenComponent in this.Animations)
		{
			ULGUIPlayTween playTween = ulguiplayTweenComponent.GetPlayTween();
			ULTweener ultweener = (playTween != null) ? playTween.GetTweener() : null;
			if (ultweener != null)
			{
				ultweener.SetSpeed(this.CurTimeScale);
			}
		}
		UUINiagara uiNiagara = base.GetUiNiagara(3);
		AActor aactor = (uiNiagara != null) ? uiNiagara.GetOwner() : null;
		if (aactor != null)
		{
			aactor.CustomTimeDilation = this.CurTimeScale;
		}
	}

	// Token: 0x0600C409 RID: 50185 RVA: 0x0033BB28 File Offset: 0x00339D28
	private void RefreshDamageLocation()
	{
		FVector2D fvector2D = ULGUIBPLibrary.ConvertWorldPosToLGUIPos(Global.CharacterController, this.DamageLocationUe);
		float x = fvector2D.X + (float)this.RandomUiPosition.X;
		float y = fvector2D.Y + (float)this.RandomUiPosition.Y;
		this.SetDamageLocation(x, y);
	}

	// Token: 0x0600C40A RID: 50186 RVA: 0x0033BB78 File Offset: 0x00339D78
	private void RefreshPlayerDamageLocation()
	{
		FVector2D fvector2D = ULGUIBPLibrary.ConvertWorldPosToLGUIPos(Global.CharacterController, this.DamageLocationUe);
		float x = fvector2D.X + (float)this.RandomUiPosition.X;
		float y = fvector2D.Y + (float)this.RandomUiPosition.Y;
		this.SetDamageLocation(x, y);
	}

	// Token: 0x0600C40B RID: 50187 RVA: 0x0033BBC8 File Offset: 0x00339DC8
	private void RefreshDepth()
	{
		int hierarchyIndex = Singleton<DamageUiManager>.Instance.TotalDamageViewNum - 1;
		this.RootItem.SetHierarchyIndex(hierarchyIndex);
	}

	// Token: 0x0600C40C RID: 50188 RVA: 0x0033BBF0 File Offset: 0x00339DF0
	private void SetCriticalNiagara(string niagaraPath)
	{
		if (this.CriticalNiagaraPath == niagaraPath)
		{
			return;
		}
		UUINiagara criticalNiagara = base.GetUiNiagara(3);
		if (StringUtils.IsEmpty(niagaraPath))
		{
			this.CriticalNiagaraPath = null;
			criticalNiagara.DeactivateSystem();
			criticalNiagara.SetNiagaraSystem(null);
			return;
		}
		this.CriticalNiagaraPath = niagaraPath;
		Singleton<ResourceSystem>.Instance.LoadAsync<UNiagaraSystem>(niagaraPath, delegate([Nullable(2)] UNiagaraSystem niagaraSystem, string _)
		{
			if (niagaraSystem == null || !niagaraSystem.IsValid())
			{
				return;
			}
			if (criticalNiagara == null)
			{
				return;
			}
			this.CriticalNiagara = niagaraSystem;
		}, 100, "js_undefined");
	}

	// Token: 0x0600C40D RID: 50189 RVA: 0x0033BC74 File Offset: 0x00339E74
	private void SetCriticalItemVisible(bool bVisible)
	{
		UUIItem item = base.GetItem(4);
		if (item.IsUIActiveSelf() == bVisible)
		{
			return;
		}
		item.SetUIActive(bVisible);
	}

	// Token: 0x0600C40E RID: 50190 RVA: 0x0033BC9C File Offset: 0x00339E9C
	public void SetCriticalNiagaraVisible(bool bVisible)
	{
		UUINiagara uiNiagara = base.GetUiNiagara(3);
		if (uiNiagara.IsUIActiveSelf() == bVisible)
		{
			return;
		}
		uiNiagara.SetUIActive(bVisible);
	}

	// Token: 0x0600C40F RID: 50191 RVA: 0x0033BCC4 File Offset: 0x00339EC4
	private void RefreshTextDisplay(string damageTextString, bool bCritical, bool bCustomText)
	{
		if (bCustomText)
		{
			this.SetDamageTextStyle(this.DamageNum, bCritical);
			if (this.DamageText.GetText() != damageTextString)
			{
				Singleton<LguiUtil>.Instance.SetLocalText(this.DamageText, damageTextString, Array.Empty<object>());
			}
			if (this.DamageNum.IsUIActiveSelf())
			{
				this.DamageNum.SetUIActive(false);
			}
			if (!this.DamageText.IsUIActiveSelf())
			{
				this.DamageText.SetUIActive(true);
				return;
			}
		}
		else
		{
			this.SetDamageTextStyle(this.DamageNum, bCritical);
			if (this.DamageNum.GetText() != damageTextString)
			{
				this.DamageNum.SetText(damageTextString, true);
			}
			if (!this.DamageNum.IsUIActiveSelf())
			{
				this.DamageNum.SetUIActive(true);
			}
			if (this.DamageText.IsUIActiveSelf())
			{
				this.DamageText.SetUIActive(false);
			}
		}
	}

	// Token: 0x0600C410 RID: 50192 RVA: 0x0033BD9C File Offset: 0x00339F9C
	private void RefreshCriticalNiagara(bool bCritical)
	{
		if (bCritical)
		{
			this.SetCriticalItemVisible(true);
			this.SetCriticalNiagara(this.DamageViewData.GetCriticalNiagaraPath());
			return;
		}
		this.SetCriticalItemVisible(false);
	}

	// Token: 0x0600C411 RID: 50193 RVA: 0x0033BDC4 File Offset: 0x00339FC4
	private void SetDamageTextStyle(UUIText damageText, bool bCritical)
	{
		UUIEffectOutline uuieffectOutline = damageText.GetOwner().GetComponentByClass(UUIEffectOutline.StaticClass()) as UUIEffectOutline;
		FColor? fcolor = this.DamageViewData.GetTextColor();
		FColor? fcolor2 = this.DamageViewData.GetStrokeColor();
		if (bCritical)
		{
			fcolor = this.DamageViewData.GetCriticalTextColor();
			fcolor2 = this.DamageViewData.GetCriticalStrokeColor();
		}
		if (!(damageText.GetColor() == fcolor.Value))
		{
			damageText.SetColor(fcolor.Value);
		}
		if (!(uuieffectOutline.GetOutlineColor() == fcolor2.Value))
		{
			uuieffectOutline.SetOutlineColor(fcolor2.Value);
		}
	}

	// Token: 0x0600C412 RID: 50194 RVA: 0x0033BE61 File Offset: 0x0033A061
	private void SetDamageLocation(float x, float y)
	{
		this.RootItem.SetAnchorOffsetX(x);
		this.RootItem.SetAnchorOffsetY(y);
	}

	// Token: 0x0600C413 RID: 50195 RVA: 0x0033BE7B File Offset: 0x0033A07B
	public void SetTimeScale(float timeScale)
	{
		this.TimeScale = timeScale;
		if (timeScale == 1f)
		{
			this.UpdateCurTimeScale(1f);
		}
	}

	// Token: 0x04005E14 RID: 24084
	private const float ANIM_TIME = 1200f;

	// Token: 0x04005E15 RID: 24085
	private const float ANIM_SCALE_TIME = 700f;

	// Token: 0x04005E16 RID: 24086
	private const float MOBLIE_FONT_SIZE_SCALE = 1.5f;

	// Token: 0x04005E17 RID: 24087
	private const float CRITICAL_OFFSET_SCALE = 1f;

	// Token: 0x04005E18 RID: 24088
	private const int MERGE_NUM = 10;

	// Token: 0x04005E19 RID: 24089
	private const float MERGE_PER_TEXT_TIME = 100f;

	// Token: 0x04005E1A RID: 24090
	private readonly Dictionary<string, int> DamageAnimMap = new Dictionary<string, int>
	{
		{
			"Ani_OwnDamageSequence",
			5
		},
		{
			"Ani_OwnCriticalDamageSequence",
			6
		},
		{
			"Ani_MonsterDamageSequence",
			7
		},
		{
			"Ani_MonsterCriticalDamageSequence",
			8
		},
		{
			"Ani_BuffSequence",
			9
		},
		{
			"Ani_SpecialDamage",
			10
		},
		{
			"Ani_SpecialCriticalDamage",
			11
		}
	};

	// Token: 0x04005E1B RID: 24091
	private readonly global::Vector DamageLocation = global::Vector.Create();

	// Token: 0x04005E1C RID: 24092
	private readonly global::Vector BaseLocation = global::Vector.Create();

	// Token: 0x04005E1D RID: 24093
	private FVectorDouble DamageLocationUe = FVectorDouble.ZeroVector;

	// Token: 0x04005E1E RID: 24094
	private readonly Vector2D RandomUiPosition = Vector2D.Create();

	// Token: 0x04005E1F RID: 24095
	[Nullable(2)]
	private UUIText DamageNum;

	// Token: 0x04005E20 RID: 24096
	[Nullable(2)]
	private UUIText DamageText;

	// Token: 0x04005E21 RID: 24097
	[Nullable(2)]
	private string CriticalNiagaraPath;

	// Token: 0x04005E22 RID: 24098
	[Nullable(2)]
	private UNiagaraSystem CriticalNiagara;

	// Token: 0x04005E23 RID: 24099
	[Nullable(2)]
	private DamageViewData DamageViewData;

	// Token: 0x04005E24 RID: 24100
	private readonly Stat StatInitializeDamageView = Stat.Create("[DamageView]InitializeDamageView", "", "");

	// Token: 0x04005E25 RID: 24101
	private float AnimEndTime;

	// Token: 0x04005E26 RID: 24102
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<ULGUIPlayTweenComponent> Animations;

	// Token: 0x04005E27 RID: 24103
	private float FontSize;

	// Token: 0x04005E28 RID: 24104
	private float TimeScale = 1f;

	// Token: 0x04005E29 RID: 24105
	private float CurTimeScale = 1f;

	// Token: 0x04005E2A RID: 24106
	private readonly List<string> TextList = new List<string>();

	// Token: 0x04005E2B RID: 24107
	private int TextIndex = -1;

	// Token: 0x04005E2C RID: 24108
	private bool IsFollowPlayer;

	// Token: 0x02007D79 RID: 32121
	[NullableContext(0)]
	private enum EChildComponentType
	{
		// Token: 0x0402ABF7 RID: 175095
		DamageNum,
		// Token: 0x0402ABF8 RID: 175096
		DamageBox,
		// Token: 0x0402ABF9 RID: 175097
		DamageText,
		// Token: 0x0402ABFA RID: 175098
		CriticalNiagara,
		// Token: 0x0402ABFB RID: 175099
		CriticalItem,
		// Token: 0x0402ABFC RID: 175100
		AnimOwnDamage,
		// Token: 0x0402ABFD RID: 175101
		AnimOwnCriticalDamage,
		// Token: 0x0402ABFE RID: 175102
		AnimMonsterDamage,
		// Token: 0x0402ABFF RID: 175103
		AnimMonsterCriticalDamage,
		// Token: 0x0402AC00 RID: 175104
		AnimBuff,
		// Token: 0x0402AC01 RID: 175105
		AnimSpecialDamage,
		// Token: 0x0402AC02 RID: 175106
		AnimSpecialCriticalDamage
	}
}
