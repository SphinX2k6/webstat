using System;
using System.Runtime.CompilerServices;

// Token: 0x02002F28 RID: 12072
[NullableContext(1)]
[Nullable(0)]
public class SetFormationAttributeRate : BuffEffect
{
	// Token: 0x06018B75 RID: 101237 RVA: 0x006FB918 File Offset: 0x006F9B18
	public SetFormationAttributeRate(int activeHandleId, int index, RequireAndLimits requireAndLimits, BaseBuffComponent ownerBuffComponent, [Nullable(2)] CharacterBuffComponent instigatorBuffComponent) : base(activeHandleId, index, requireAndLimits, ownerBuffComponent, instigatorBuffComponent)
	{
	}

	// Token: 0x06018B76 RID: 101238 RVA: 0x006FB927 File Offset: 0x006F9B27
	protected override bool CheckExecutable()
	{
		IBuffComponent ownerBuffComponent = this.OwnerBuffComponent;
		return ownerBuffComponent != null && ownerBuffComponent.HasBuffAuthority();
	}

	// Token: 0x06018B77 RID: 101239 RVA: 0x006FB93C File Offset: 0x006F9B3C
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

	// Token: 0x06018B78 RID: 101240 RVA: 0x006FB9F1 File Offset: 0x006F9BF1
	public override void OnCreated()
	{
		if (this.AttributeId == null)
		{
			return;
		}
		if (this.CheckExecutable())
		{
			ControllerBase<FormationAttributeController>.Instance.AddSpeedModifier(this.ModifierHandle, this.AttributeId.Value, EModifierType.Override, this.Rate, 100);
		}
	}

	// Token: 0x06018B79 RID: 101241 RVA: 0x006FBA2D File Offset: 0x006F9C2D
	[return: Nullable(2)]
	public override object OnExecute(params object[] parameters)
	{
		return null;
	}

	// Token: 0x06018B7A RID: 101242 RVA: 0x006FBA30 File Offset: 0x006F9C30
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

	// Token: 0x0400C086 RID: 49286
	protected EFormationAttributeId? AttributeId;

	// Token: 0x0400C087 RID: 49287
	protected float Rate;

	// Token: 0x0400C088 RID: 49288
	[Nullable(2)]
	protected string ModifierHandle;
}
