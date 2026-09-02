using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200132C RID: 4908
[NullableContext(1)]
[Nullable(0)]
public class FightPhotoEventTipView : UiTickViewBase
{
	// Token: 0x060085D9 RID: 34265 RVA: 0x00234122 File Offset: 0x00232322
	public FightPhotoEventTipView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060085DA RID: 34266 RVA: 0x00234144 File Offset: 0x00232344
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIText))
		};
	}

	// Token: 0x060085DB RID: 34267 RVA: 0x002341A0 File Offset: 0x002323A0
	protected override UniTask OnBeforeStartAsync()
	{
		FightPhotoEventTipView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<FightPhotoEventTipView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060085DC RID: 34268 RVA: 0x002341E4 File Offset: 0x002323E4
	protected override void OnStart()
	{
		IPromptParamHub promptParamHub = (IPromptParamHub)this.OpenParam;
		TableTextArgNew mainTextObj = promptParamHub.MainTextObj;
		string text = ((mainTextObj != null) ? mainTextObj.TextKey : null) ?? "";
		if (!string.IsNullOrEmpty(text))
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), text, Array.Empty<object>());
		}
		int tipType = Array.IndexOf<string>(ControllerBase<FightPhotoController>.Instance.StepTextIdList, text);
		this.SetTipType(tipType);
		int num = 3;
		if (promptParamHub.Duration != null && promptParamHub.Duration.Value != 0f)
		{
			num = (int)promptParamHub.Duration.Value;
		}
		else if (promptParamHub.TypeId != 0)
		{
			GenericPromptTypes? promptTypeInfo = ConfigBase<GenericPromptConfig>.Instance.GetPromptTypeInfo(promptParamHub.TypeId);
			if (promptTypeInfo != null)
			{
				num = promptTypeInfo.Value.Duration;
			}
		}
		this.Duration = (float)(num * Singleton<TimeUtil>.Instance.InverseMillisecond);
	}

	// Token: 0x060085DD RID: 34269 RVA: 0x002342D3 File Offset: 0x002324D3
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnPreparePhotoScreenShot, new Action<bool>(this.OnPreparePhotoScreenShot));
	}

	// Token: 0x060085DE RID: 34270 RVA: 0x002342F1 File Offset: 0x002324F1
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPreparePhotoScreenShot, new Action<bool>(this.OnPreparePhotoScreenShot));
	}

	// Token: 0x060085DF RID: 34271 RVA: 0x0023430F File Offset: 0x0023250F
	protected override void OnBeforeDestroy()
	{
		this.PatternTextureMap.Clear();
		this.NumberTextureMap.Clear();
	}

	// Token: 0x060085E0 RID: 34272 RVA: 0x00234327 File Offset: 0x00232527
	protected override void OnTick(float delta)
	{
		if (this.IsOverTime)
		{
			return;
		}
		this.TickTime += delta;
		if (this.TickTime > this.Duration)
		{
			this.IsOverTime = true;
			base.CloseMe(null);
		}
	}

	// Token: 0x060085E1 RID: 34273 RVA: 0x0023435C File Offset: 0x0023255C
	private void SetTipType(int tipType)
	{
		UTexture2D texture;
		if (this.PatternTextureMap.TryGetValue(tipType, out texture))
		{
			UUITexture texture2 = base.GetTexture(0);
			if (texture2 != null)
			{
				texture2.SetTexture(texture);
			}
			UUITexture texture3 = base.GetTexture(0);
			if (texture3 != null)
			{
				texture3.SetUIActive(true);
			}
		}
		else
		{
			UUITexture texture4 = base.GetTexture(0);
			if (texture4 != null)
			{
				texture4.SetUIActive(false);
			}
		}
		UTexture2D texture5;
		if (this.NumberTextureMap.TryGetValue(tipType, out texture5))
		{
			UUITexture texture6 = base.GetTexture(1);
			if (texture6 != null)
			{
				texture6.SetTexture(texture5);
			}
			UUITexture texture7 = base.GetTexture(1);
			if (texture7 == null)
			{
				return;
			}
			texture7.SetUIActive(true);
			return;
		}
		else
		{
			UUITexture texture8 = base.GetTexture(1);
			if (texture8 == null)
			{
				return;
			}
			texture8.SetUIActive(false);
			return;
		}
	}

	// Token: 0x060085E2 RID: 34274 RVA: 0x002343FC File Offset: 0x002325FC
	private UniTask LoadTexture(string path, Dictionary<int, UTexture2D> container, int key)
	{
		FightPhotoEventTipView.<LoadTexture>d__18 <LoadTexture>d__;
		<LoadTexture>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<LoadTexture>d__.<>4__this = this;
		<LoadTexture>d__.path = path;
		<LoadTexture>d__.container = container;
		<LoadTexture>d__.key = key;
		<LoadTexture>d__.<>1__state = -1;
		<LoadTexture>d__.<>t__builder.Start<FightPhotoEventTipView.<LoadTexture>d__18>(ref <LoadTexture>d__);
		return <LoadTexture>d__.<>t__builder.Task;
	}

	// Token: 0x060085E3 RID: 34275 RVA: 0x00234457 File Offset: 0x00232657
	public void OnPreparePhotoScreenShot(bool bShow)
	{
		if (base.IsShowOrShowing)
		{
			UUIItem rootItem = base.GetRootItem();
			if (rootItem == null)
			{
				return;
			}
			rootItem.SetUIActive(bShow);
		}
	}

	// Token: 0x04003F57 RID: 16215
	[StaticVariableRuleIgnore]
	private static readonly string[] PatternTextureList = new string[]
	{
		"/Game/Aki/UI/UIResources/Common/Image/Com/Photo/T_BattlePhotoPatternNum01.T_BattlePhotoPatternNum01",
		"/Game/Aki/UI/UIResources/Common/Image/Com/Photo/T_BattlePhotoPatternNum02.T_BattlePhotoPatternNum02",
		"/Game/Aki/UI/UIResources/Common/Image/Com/Photo/T_BattlePhotoPatternNum03.T_BattlePhotoPatternNum03"
	};

	// Token: 0x04003F58 RID: 16216
	[StaticVariableRuleIgnore]
	private static readonly string[] NumberTextureList = new string[]
	{
		"/Game/Aki/UI/UIResources/Common/Image/Com/Photo/T_BattlePhotoNum01.T_BattlePhotoNum01",
		"/Game/Aki/UI/UIResources/Common/Image/Com/Photo/T_BattlePhotoNum02.T_BattlePhotoNum02",
		"/Game/Aki/UI/UIResources/Common/Image/Com/Photo/T_BattlePhotoNum03.T_BattlePhotoNum03"
	};

	// Token: 0x04003F59 RID: 16217
	private const int DEFAULT_TIP_DURATION = 3;

	// Token: 0x04003F5A RID: 16218
	private readonly Dictionary<int, UTexture2D> PatternTextureMap = new Dictionary<int, UTexture2D>();

	// Token: 0x04003F5B RID: 16219
	private readonly Dictionary<int, UTexture2D> NumberTextureMap = new Dictionary<int, UTexture2D>();

	// Token: 0x04003F5C RID: 16220
	private float Duration;

	// Token: 0x04003F5D RID: 16221
	private float TickTime;

	// Token: 0x04003F5E RID: 16222
	private bool IsOverTime;

	// Token: 0x020076CB RID: 30411
	[NullableContext(0)]
	private enum EComponentType
	{
		// Token: 0x04028EA3 RID: 167587
		PatternTexture,
		// Token: 0x04028EA4 RID: 167588
		NumberTexture,
		// Token: 0x04028EA5 RID: 167589
		TipText
	}
}
