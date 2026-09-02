using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Core.Extension;
using CSharpScript.Game.Camera;

// Token: 0x02002FAD RID: 12205
[NullableContext(2)]
[Nullable(0)]
public class GameplayCueMagnitude : GameplayCueBase
{
	// Token: 0x06018E2B RID: 101931 RVA: 0x0070C6F0 File Offset: 0x0070A8F0
	protected override void OnInit()
	{
		this.Min = (float)this.CueConfig.Min;
		this.Max = (float)this.CueConfig.Max;
	}

	// Token: 0x06018E2C RID: 101932 RVA: 0x0070C718 File Offset: 0x0070A918
	protected override void OnTick(float delta)
	{
		base.OnTick(delta);
		if (this.BuffIdNeedTick != 0)
		{
			float num = this.ComputeMagnitudeValueByBuff();
			this.SetMagnitude(num, false);
			if (num == 0f)
			{
				this.BuffIdNeedTick = 0;
				return;
			}
		}
		else if (this.CameraPitchTick)
		{
			if (!Singleton<MathUtils>.Instance.IsNearlyEqual((double)this.Value, (double)ControllerBase<CameraController>.Instance.MainModel.CameraRotator.Pitch, null))
			{
				this.SetMagnitude(ControllerBase<CameraController>.Instance.MainModel.CameraRotator.Pitch, false);
				return;
			}
		}
		else if (this.ExistFlowTimeTick)
		{
			this.SetMagnitude((float)Singleton<Time>.Instance.FlowTime - this.StartFlowTime, false);
		}
	}

	// Token: 0x06018E2D RID: 101933 RVA: 0x0070C7CF File Offset: 0x0070A9CF
	protected override void OnCreate()
	{
		this.InitComponent();
		this.IsMagnified = this.StartMagnify();
	}

	// Token: 0x06018E2E RID: 101934 RVA: 0x0070C7E3 File Offset: 0x0070A9E3
	protected override void OnDestroy()
	{
		this.StopMagnify();
	}

	// Token: 0x06018E2F RID: 101935 RVA: 0x0070C7EB File Offset: 0x0070A9EB
	protected virtual void OnSetMagnitude(float normalizedValue)
	{
	}

	// Token: 0x06018E30 RID: 101936 RVA: 0x0070C7ED File Offset: 0x0070A9ED
	[NullableContext(1)]
	public override void OnChangeRole(EntityHandle newEntityHandle)
	{
		this.StopMagnify();
		base.OnChangeRole(newEntityHandle);
		this.InitComponent();
		this.IsMagnified = this.StartMagnify();
	}

	// Token: 0x06018E31 RID: 101937 RVA: 0x0070C80E File Offset: 0x0070AA0E
	protected virtual bool UseMagnitude()
	{
		return this.CueConfig.Magni != 0 && !this.IsInstant;
	}

	// Token: 0x06018E32 RID: 101938 RVA: 0x0070C828 File Offset: 0x0070AA28
	[NullableContext(1)]
	public virtual void SyncMagnitude(GameplayCueMagnitude cueRef)
	{
	}

	// Token: 0x06018E33 RID: 101939 RVA: 0x0070C82A File Offset: 0x0070AA2A
	private bool HasMagnitudeComponent()
	{
		return this.AttributeComponent != null && this.BuffComponent != null && this.TagComponent != null;
	}

	// Token: 0x06018E34 RID: 101940 RVA: 0x0070C848 File Offset: 0x0070AA48
	private bool StartMagnify()
	{
		if (!this.UseMagnitude() || !this.HasMagnitudeComponent())
		{
			return false;
		}
		float value;
		switch (this.CueConfig.Magni)
		{
		case 1:
			if (!this.Check(this.CueConfig.AttrId != 0, "属性Id没填！"))
			{
				return false;
			}
			this.MaxAttributeId = CharacterAttributeTypes.attributeIdsWithMax.GetValueOrNull((EAttributeType)this.CueConfig.AttrId);
			if (this.CueConfig.BListenAttr)
			{
				this.AttributeComponent.AddListener((EAttributeType)this.CueConfig.AttrId, new Action<EAttributeType, float, float>(this.OnAttributeChanged), "GameplayCueMagnitude");
				if (this.MaxAttributeId != null)
				{
					this.AttributeComponent.AddListener(this.MaxAttributeId.Value, new Action<EAttributeType, float, float>(this.OnAttributeChanged), "GameplayCueMagnitudeMax");
				}
			}
			value = this.AttributeComponent.GetCurrentValue((EAttributeType)this.CueConfig.AttrId);
			if (this.MaxAttributeId != null)
			{
				this.Max = this.AttributeComponent.GetCurrentValue(this.MaxAttributeId.Value);
			}
			break;
		case 2:
		{
			if (!this.Check(!string.IsNullOrEmpty(this.CueConfig.Tag), "Tag没填！"))
			{
				return false;
			}
			int tagIdByName = GameplayTagUtils.GetTagIdByName(this.CueConfig.Tag);
			if (this.CueConfig.BListenAttr)
			{
				this.TagCountChangedTask = this.TagComponent.ListenForTagAnyCountChanged(tagIdByName, new BaseTagComponent.TTagChangedCallback(this.OnTagCountChanged));
			}
			value = (float)this.TagComponent.GetTagCount(tagIdByName);
			break;
		}
		case 3:
		{
			IActiveBuff buffByHandle = this.BuffComponent.GetBuffByHandle(this.BuffHandleId);
			int? num = (buffByHandle != null) ? new int?(buffByHandle.Level) : null;
			value = ((num != null) ? ((float)num.GetValueOrDefault()) : 1f);
			break;
		}
		case 4:
			if (this.CueConfig.BListenAttr)
			{
				this.BuffIdNeedTick = this.BuffHandleId;
			}
			value = this.ComputeMagnitudeValueByBuff();
			break;
		case 5:
			this.CameraPitchTick = this.CueConfig.BListenAttr;
			value = ControllerBase<CameraController>.Instance.MainModel.CameraRotator.Pitch;
			break;
		case 6:
			this.StartFlowTime = (float)Singleton<Time>.Instance.FlowTime;
			this.ExistFlowTimeTick = true;
			value = 0f;
			break;
		default:
			return false;
		}
		return this.SetMagnitude(value, true);
	}

	// Token: 0x06018E35 RID: 101941 RVA: 0x0070CAAC File Offset: 0x0070ACAC
	private void StopMagnify()
	{
		if (!this.IsMagnified)
		{
			return;
		}
		switch (this.CueConfig.Magni)
		{
		case 1:
			if (this.CueConfig.BListenAttr)
			{
				this.AttributeComponent.RemoveListener((EAttributeType)this.CueConfig.AttrId, new Action<EAttributeType, float, float>(this.OnAttributeChanged));
				if (this.MaxAttributeId != null)
				{
					this.AttributeComponent.RemoveListener(this.MaxAttributeId.Value, new Action<EAttributeType, float, float>(this.OnAttributeChanged));
					return;
				}
			}
			break;
		case 2:
			if (this.CueConfig.BListenAttr && this.TagCountChangedTask != null)
			{
				this.TagCountChangedTask.EndTask();
				this.TagCountChangedTask = null;
				return;
			}
			break;
		case 3:
			break;
		case 4:
			if (this.CueConfig.BListenAttr)
			{
				this.BuffIdNeedTick = 0;
				return;
			}
			break;
		case 5:
			this.CameraPitchTick = false;
			return;
		case 6:
			this.ExistFlowTimeTick = false;
			break;
		default:
			return;
		}
	}

	// Token: 0x06018E36 RID: 101942 RVA: 0x0070CBA0 File Offset: 0x0070ADA0
	private void OnAttributeChanged(EAttributeType attributeId, float newValue, float oldValue)
	{
		EAttributeType? maxAttributeId = this.MaxAttributeId;
		if (attributeId == maxAttributeId.GetValueOrDefault() & maxAttributeId != null)
		{
			this.Max = newValue;
		}
		else
		{
			this.Value = newValue;
		}
		this.SetMagnitude(this.Value, true);
	}

	// Token: 0x06018E37 RID: 101943 RVA: 0x0070CBE6 File Offset: 0x0070ADE6
	private void OnTagCountChanged(int tagCount, int tagId, int exactTagId, int oldCount)
	{
		this.SetMagnitude((float)tagCount, true);
	}

	// Token: 0x06018E38 RID: 101944 RVA: 0x0070CBF4 File Offset: 0x0070ADF4
	private bool SetMagnitude(float value, bool isLog = true)
	{
		if (!this.Check(this.Max >= this.Min, "Buff特效表Min>Max！有问题"))
		{
			return false;
		}
		this.Value = value;
		float normalizedValue = this.Normalize();
		this.OnSetMagnitude(normalizedValue);
		return true;
	}

	// Token: 0x06018E39 RID: 101945 RVA: 0x0070CC3C File Offset: 0x0070AE3C
	protected virtual float Normalize()
	{
		if (this.BuffIdNeedTick != 0)
		{
			return this.Value;
		}
		if (this.Min == this.Max)
		{
			return 0f;
		}
		return (Singleton<MathUtils>.Instance.Clamp(this.Value, this.Min, this.Max) - this.Min) / (this.Max - this.Min);
	}

	// Token: 0x06018E3A RID: 101946 RVA: 0x0070CC9D File Offset: 0x0070AE9D
	protected float ToRange(float normalizedValue)
	{
		return normalizedValue * (this.Max - this.Min) + this.Min;
	}

	// Token: 0x06018E3B RID: 101947 RVA: 0x0070CCB8 File Offset: 0x0070AEB8
	[NullableContext(1)]
	private bool Check(bool toCheck, string message)
	{
		if (!toCheck)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Battle;
			ELogAuthor author = ELogAuthor.HXY;
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("CueId", this.CueConfig.Id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		return true;
	}

	// Token: 0x06018E3C RID: 101948 RVA: 0x0070CD00 File Offset: 0x0070AF00
	private float ComputeMagnitudeValueByBuff()
	{
		IActiveBuff buffByHandle = this.BuffComponent.GetBuffByHandle(this.BuffHandleId);
		float num = (buffByHandle != null) ? buffByHandle.GetRemainDuration() : 0f;
		IActiveBuff buffByHandle2 = this.BuffComponent.GetBuffByHandle(this.BuffHandleId);
		float num2 = (buffByHandle2 != null) ? buffByHandle2.Duration : 1f;
		if (num2 > 0f)
		{
			return num / num2;
		}
		return 0f;
	}

	// Token: 0x06018E3D RID: 101949 RVA: 0x0070CD64 File Offset: 0x0070AF64
	private void InitComponent()
	{
		this.AttributeComponent = this.EntityHandle.Entity.CheckGetComponent<BaseAttributeComponent>();
		this.BuffComponent = this.EntityHandle.Entity.CheckGetComponent<BaseBuffComponent>();
		this.TagComponent = this.EntityHandle.Entity.CheckGetComponent<BaseTagComponent>();
	}

	// Token: 0x0400C274 RID: 49780
	private bool IsMagnified;

	// Token: 0x0400C275 RID: 49781
	private ITagTask TagCountChangedTask;

	// Token: 0x0400C276 RID: 49782
	private BaseAttributeComponent AttributeComponent;

	// Token: 0x0400C277 RID: 49783
	private BaseTagComponent TagComponent;

	// Token: 0x0400C278 RID: 49784
	private BaseBuffComponent BuffComponent;

	// Token: 0x0400C279 RID: 49785
	private EAttributeType? MaxAttributeId;

	// Token: 0x0400C27A RID: 49786
	private float Min;

	// Token: 0x0400C27B RID: 49787
	private float Max;

	// Token: 0x0400C27C RID: 49788
	protected float Value;

	// Token: 0x0400C27D RID: 49789
	private int BuffIdNeedTick;

	// Token: 0x0400C27E RID: 49790
	private bool CameraPitchTick;

	// Token: 0x0400C27F RID: 49791
	private float StartFlowTime;

	// Token: 0x0400C280 RID: 49792
	private bool ExistFlowTimeTick;
}
