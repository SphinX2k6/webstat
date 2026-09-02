using System;
using System.Runtime.CompilerServices;

// Token: 0x02002F42 RID: 12098
[NullableContext(1)]
[Nullable(0)]
public class ModifyBuffTimeScale : BuffEffect
{
	// Token: 0x06018C19 RID: 101401 RVA: 0x006FF3DF File Offset: 0x006FD5DF
	public ModifyBuffTimeScale(int activeHandleId, int index, RequireAndLimits requireAndLimits, BaseBuffComponent ownerBuffComponent, [Nullable(2)] CharacterBuffComponent instigatorBuffComponent) : base(activeHandleId, index, requireAndLimits, ownerBuffComponent, instigatorBuffComponent)
	{
	}

	// Token: 0x06018C1A RID: 101402 RVA: 0x006FF404 File Offset: 0x006FD604
	protected override void InitParameters(ExtraEffectParameters parameters)
	{
		string[] extraEffectParameters_ = parameters.ExtraEffectParameters_;
		if (extraEffectParameters_ == null || extraEffectParameters_.Length < 3)
		{
			return;
		}
		string[] array = extraEffectParameters_[0].Split('#', StringSplitOptions.None);
		if (array.Length != 0)
		{
			this.ChangePreBuff = (int.Parse(array[0]) == 1);
		}
		if (array.Length > 1)
		{
			this.ChangeBuffIfInDuration = (int.Parse(array[1]) == 1);
		}
		string[] array2 = extraEffectParameters_[1].Split('#', StringSplitOptions.None);
		this.BuffIds = new long[array2.Length];
		for (int i = 0; i < array2.Length; i++)
		{
			this.BuffIds[i] = long.Parse(array2[i]);
		}
		this.TimeScale = (float)int.Parse(extraEffectParameters_[2]) * 0.0001f;
	}

	// Token: 0x06018C1B RID: 101403 RVA: 0x006FF4A8 File Offset: 0x006FD6A8
	public override void OnCreated()
	{
		IBuffComponent ownerBuffComponent = this.OwnerBuffComponent;
		if (ownerBuffComponent == null)
		{
			return;
		}
		if (this.ChangePreBuff)
		{
			foreach (long buffId in this.BuffIds)
			{
				foreach (ActiveBuffInternal activeBuffInternal in ownerBuffComponent.GetAllBuffById(buffId))
				{
					activeBuffInternal.SetBuffTimeScale(this.ActiveHandleId, this.TimeScale);
				}
			}
		}
		Entity ownerEntity = base.OwnerEntity;
		if (this.ChangeBuffIfInDuration && ownerEntity != null)
		{
			foreach (long key in this.BuffIds)
			{
				AbilityEvent.Instance.Add(ownerEntity, EAbilityEventName.OnBuffAdd, key, new Action<long, int>(this.OnBuffAdd));
			}
		}
	}

	// Token: 0x06018C1C RID: 101404 RVA: 0x006FF578 File Offset: 0x006FD778
	private void OnBuffAdd(long buffId, int handle)
	{
		IBuffComponent ownerBuffComponent = this.OwnerBuffComponent;
		IActiveBuff activeBuff = (ownerBuffComponent != null) ? ownerBuffComponent.GetBuffByHandle(handle) : null;
		if (activeBuff == null)
		{
			return;
		}
		activeBuff.SetBuffTimeScale(this.ActiveHandleId, this.TimeScale);
	}

	// Token: 0x06018C1D RID: 101405 RVA: 0x006FF5A4 File Offset: 0x006FD7A4
	public override void OnRemoved(bool bPremature)
	{
		IBuffComponent ownerBuffComponent = this.OwnerBuffComponent;
		if (ownerBuffComponent == null)
		{
			return;
		}
		foreach (long buffId in this.BuffIds)
		{
			foreach (ActiveBuffInternal activeBuffInternal in ownerBuffComponent.GetAllBuffById(buffId))
			{
				activeBuffInternal.RemoveBuffTimeScale(this.ActiveHandleId);
			}
		}
		Entity ownerEntity = base.OwnerEntity;
		if (this.ChangeBuffIfInDuration && ownerEntity != null)
		{
			foreach (long key in this.BuffIds)
			{
				AbilityEvent.Instance.Remove(ownerEntity, EAbilityEventName.OnBuffAdd, key, new Action<long, int>(this.OnBuffAdd));
			}
		}
	}

	// Token: 0x06018C1E RID: 101406 RVA: 0x006FF668 File Offset: 0x006FD868
	[return: Nullable(2)]
	public override object OnExecute(params object[] parameters)
	{
		return null;
	}

	// Token: 0x06018C1F RID: 101407 RVA: 0x006FF66C File Offset: 0x006FD86C
	public override string GetDebugEffectString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(39, 4);
		defaultInterpolatedStringHandler.AppendLiteral("修改buff");
		defaultInterpolatedStringHandler.AppendFormatted(string.Join<long>(",", this.BuffIds));
		defaultInterpolatedStringHandler.AppendLiteral("的时间缩放为");
		defaultInterpolatedStringHandler.AppendFormatted<float>(this.TimeScale);
		defaultInterpolatedStringHandler.AppendLiteral(",创建前的buff是否修改");
		defaultInterpolatedStringHandler.AppendFormatted<bool>(this.ChangePreBuff);
		defaultInterpolatedStringHandler.AppendLiteral(",创建之后的buff是否修改");
		defaultInterpolatedStringHandler.AppendFormatted<bool>(this.ChangeBuffIfInDuration);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x0400C0D2 RID: 49362
	private bool ChangePreBuff;

	// Token: 0x0400C0D3 RID: 49363
	private bool ChangeBuffIfInDuration;

	// Token: 0x0400C0D4 RID: 49364
	private long[] BuffIds = Array.Empty<long>();

	// Token: 0x0400C0D5 RID: 49365
	private float TimeScale = 1f;
}
