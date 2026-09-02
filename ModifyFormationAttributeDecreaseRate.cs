using System;
using System.Runtime.CompilerServices;

// Token: 0x02002F2A RID: 12074
[NullableContext(1)]
[Nullable(0)]
public class ModifyFormationAttributeDecreaseRate : BuffEffect
{
	// Token: 0x06018B81 RID: 101249 RVA: 0x006FBBAF File Offset: 0x006F9DAF
	public ModifyFormationAttributeDecreaseRate(int activeHandleId, int index, RequireAndLimits requireAndLimits, BaseBuffComponent ownerBuffComponent, [Nullable(2)] CharacterBuffComponent instigatorBuffComponent) : base(activeHandleId, index, requireAndLimits, ownerBuffComponent, instigatorBuffComponent)
	{
	}

	// Token: 0x06018B82 RID: 101250 RVA: 0x006FBBBE File Offset: 0x006F9DBE
	protected override bool CheckExecutable()
	{
		IBuffComponent ownerBuffComponent = this.OwnerBuffComponent;
		return ownerBuffComponent != null && ownerBuffComponent.HasBuffAuthority();
	}

	// Token: 0x06018B83 RID: 101251 RVA: 0x006FBBD4 File Offset: 0x006F9DD4
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

	// Token: 0x06018B84 RID: 101252 RVA: 0x006FBC89 File Offset: 0x006F9E89
	public override void OnCreated()
	{
		if (this.AttributeId == null)
		{
			return;
		}
		if (this.CheckExecutable())
		{
			ControllerBase<FormationAttributeController>.Instance.AddSpeedModifier(this.ModifierHandle, this.AttributeId.Value, EModifierType.DecreaseModify, this.Rate, 100);
		}
	}

	// Token: 0x06018B85 RID: 101253 RVA: 0x006FBCC5 File Offset: 0x006F9EC5
	[return: Nullable(2)]
	public override object OnExecute(params object[] parameters)
	{
		return null;
	}

	// Token: 0x06018B86 RID: 101254 RVA: 0x006FBCC8 File Offset: 0x006F9EC8
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

	// Token: 0x0400C08C RID: 49292
	protected EFormationAttributeId? AttributeId;

	// Token: 0x0400C08D RID: 49293
	protected float Rate;

	// Token: 0x0400C08E RID: 49294
	[Nullable(2)]
	protected string ModifierHandle;
}
