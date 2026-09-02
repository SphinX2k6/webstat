using System;
using System.Runtime.CompilerServices;

// Token: 0x02002F29 RID: 12073
[NullableContext(1)]
[Nullable(0)]
public class ModifyFormationAttributeIncreaseRate : BuffEffect
{
	// Token: 0x06018B7B RID: 101243 RVA: 0x006FBA63 File Offset: 0x006F9C63
	public ModifyFormationAttributeIncreaseRate(int activeHandleId, int index, RequireAndLimits requireAndLimits, BaseBuffComponent ownerBuffComponent, [Nullable(2)] CharacterBuffComponent instigatorBuffComponent) : base(activeHandleId, index, requireAndLimits, ownerBuffComponent, instigatorBuffComponent)
	{
	}

	// Token: 0x06018B7C RID: 101244 RVA: 0x006FBA72 File Offset: 0x006F9C72
	protected override bool CheckExecutable()
	{
		IBuffComponent ownerBuffComponent = this.OwnerBuffComponent;
		return ownerBuffComponent != null && ownerBuffComponent.HasBuffAuthority();
	}

	// Token: 0x06018B7D RID: 101245 RVA: 0x006FBA88 File Offset: 0x006F9C88
	protected override void InitParameters(ExtraEffectParameters parameters)
	{
		string[] extraEffectParameters_ = parameters.ExtraEffectParameters_;
		if (extraEffectParameters_ == null || extraEffectParameters_.Length == 0 || string.IsNullOrEmpty(extraEffectParameters_[0]))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Battle;
			ELogAuthor author = ELogAuthor.ZQR;
			string message = "SetFormationAttributeRate参数错误，没有合法的队伍属性id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("buffId", this.BuffId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.AttributeId = new EFormationAttributeId?((EFormationAttributeId)int.Parse(extraEffectParameters_[0]));
		this.Rate = AbilityUtils.GetLevelValue<float>(parameters.ExtraEffectGrowParameters1, this.Level, 0f);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 1);
		defaultInterpolatedStringHandler.AppendLiteral("buff");
		defaultInterpolatedStringHandler.AppendFormatted<int>(this.ActiveHandleId);
		this.ModifierHandle = defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x06018B7E RID: 101246 RVA: 0x006FBB3D File Offset: 0x006F9D3D
	public override void OnCreated()
	{
		if (this.AttributeId == null)
		{
			return;
		}
		if (this.CheckExecutable())
		{
			ControllerBase<FormationAttributeController>.Instance.AddSpeedModifier(this.ModifierHandle, this.AttributeId.Value, EModifierType.IncreaseModify, this.Rate, 100);
		}
	}

	// Token: 0x06018B7F RID: 101247 RVA: 0x006FBB79 File Offset: 0x006F9D79
	[return: Nullable(2)]
	public override object OnExecute(params object[] parameters)
	{
		return null;
	}

	// Token: 0x06018B80 RID: 101248 RVA: 0x006FBB7C File Offset: 0x006F9D7C
	public override void OnRemoved(bool bPremature)
	{
		if (this.AttributeId == null)
		{
			return;
		}
		if (this.CheckExecutable())
		{
			ControllerBase<FormationAttributeController>.Instance.RemoveSpeedModifier(this.ModifierHandle, this.AttributeId.Value);
		}
	}

	// Token: 0x0400C089 RID: 49289
	protected EFormationAttributeId? AttributeId;

	// Token: 0x0400C08A RID: 49290
	protected float Rate;

	// Token: 0x0400C08B RID: 49291
	[Nullable(2)]
	protected string ModifierHandle;
}
