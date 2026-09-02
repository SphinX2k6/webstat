using System;
using System.Runtime.CompilerServices;

// Token: 0x02002F37 RID: 12087
[NullableContext(1)]
[Nullable(0)]
public class FrozenEffect : BuffEffect
{
	// Token: 0x06018BDF RID: 101343 RVA: 0x006FDB48 File Offset: 0x006FBD48
	public FrozenEffect(int activeHandleId, int index, RequireAndLimits requireAndLimits, BaseBuffComponent ownerBuffComponent, [Nullable(2)] CharacterBuffComponent instigatorBuffComponent) : base(activeHandleId, index, requireAndLimits, ownerBuffComponent, instigatorBuffComponent)
	{
	}

	// Token: 0x06018BE0 RID: 101344 RVA: 0x006FDB64 File Offset: 0x006FBD64
	protected override void InitParameters(ExtraEffectParameters parameters)
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
		defaultInterpolatedStringHandler.AppendFormatted<int>(this.ActiveHandleId);
		this.LockName = defaultInterpolatedStringHandler.ToStringAndClear();
		string[] extraEffectParameters_ = parameters.ExtraEffectParameters_;
		if (extraEffectParameters_ != null && extraEffectParameters_.Length != 0)
		{
			this.PanelQteId = int.Parse(extraEffectParameters_[0]);
		}
	}

	// Token: 0x06018BE1 RID: 101345 RVA: 0x006FDBB0 File Offset: 0x006FBDB0
	public override void OnCreated()
	{
		IBuffComponent ownerBuffComponent = this.OwnerBuffComponent;
		object obj;
		if (ownerBuffComponent == null)
		{
			obj = null;
		}
		else
		{
			Entity entity = ownerBuffComponent.GetEntity();
			obj = ((entity != null) ? entity.CheckGetComponent<BaseFrozenComponent>() : null);
		}
		object obj2 = obj;
		if (obj2 != null)
		{
			obj2.LockFrozen(this.LockName);
		}
		if (this.PanelQteId != 0)
		{
			PanelQteController instance = ControllerBase<PanelQteController>.Instance;
			int panelQteId = this.PanelQteId;
			long buffId = this.BuffId;
			int activeHandleId = this.ActiveHandleId;
			IBuffComponent ownerBuffComponent2 = this.OwnerBuffComponent;
			this.PanelQteHandleId = instance.StartBuffQte(panelQteId, buffId, activeHandleId, (ownerBuffComponent2 != null) ? ownerBuffComponent2.GetEntity() : null, base.Buff.MessageId);
		}
	}

	// Token: 0x06018BE2 RID: 101346 RVA: 0x006FDC33 File Offset: 0x006FBE33
	[return: Nullable(2)]
	public override object OnExecute(params object[] parameters)
	{
		return null;
	}

	// Token: 0x06018BE3 RID: 101347 RVA: 0x006FDC38 File Offset: 0x006FBE38
	public override void OnRemoved(bool bPremature)
	{
		IBuffComponent ownerBuffComponent = this.OwnerBuffComponent;
		object obj;
		if (ownerBuffComponent == null)
		{
			obj = null;
		}
		else
		{
			Entity entity = ownerBuffComponent.GetEntity();
			obj = ((entity != null) ? entity.CheckGetComponent<BaseFrozenComponent>() : null);
		}
		object obj2 = obj;
		if (obj2 != null)
		{
			obj2.UnlockFrozen(this.LockName);
		}
		if (this.PanelQteId != 0 && this.PanelQteHandleId > 0)
		{
			ControllerBase<PanelQteController>.Instance.StopQte(this.PanelQteHandleId, false);
		}
	}

	// Token: 0x06018BE4 RID: 101348 RVA: 0x006FDC98 File Offset: 0x006FBE98
	public override string GetDebugEffectString()
	{
		string str = "冻结";
		string str2;
		if (this.PanelQteId <= 0)
		{
			str2 = "";
		}
		else
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(6, 1);
			defaultInterpolatedStringHandler.AppendLiteral("并播放QTE");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.PanelQteId);
			str2 = defaultInterpolatedStringHandler.ToStringAndClear();
		}
		return str + str2;
	}

	// Token: 0x0400C0B1 RID: 49329
	protected string LockName = "";

	// Token: 0x0400C0B2 RID: 49330
	protected int PanelQteId;

	// Token: 0x0400C0B3 RID: 49331
	protected int PanelQteHandleId;
}
