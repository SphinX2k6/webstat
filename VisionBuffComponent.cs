using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;
using AkiClient.Game.Aki.Character.Vision;

// Token: 0x02002FE9 RID: 12265
[NullableContext(1)]
[Nullable(0)]
public class VisionBuffComponent : CharacterBuffComponent
{
	// Token: 0x06018FD9 RID: 102361 RVA: 0x00715FEC File Offset: 0x007141EC
	private bool NeedTransfer()
	{
		if (this.NeedNeedTransferFlag != null)
		{
			return this.NeedNeedTransferFlag.Value;
		}
		CharacterFollowComponent component = base.Entity.GetComponent<CharacterFollowComponent>();
		Entity entity = (component != null) ? component.GetAttributeHolder() : null;
		if (entity == null)
		{
			return false;
		}
		if (entity == base.Entity)
		{
			return false;
		}
		VisionComponent visionComponent = this.CreatureDataComponent.GetVisionComponent();
		if (visionComponent != null)
		{
			SVisionData visionData = PhantomUtil.GetVisionData(visionComponent.VisionId);
			this.NeedNeedTransferFlag = new bool?(visionData != null && visionData.buff是否转移);
		}
		return this.NeedNeedTransferFlag.GetValueOrDefault();
	}

	// Token: 0x06018FDA RID: 102362 RVA: 0x00716078 File Offset: 0x00714278
	public unsafe override void AddBuff(long buffId, AddBuffParam buffParams)
	{
		if (base.CreatureDataId == buffParams.InstigatorId || !this.NeedTransfer())
		{
			base.AddBuff(buffId, buffParams);
			return;
		}
		CharacterFollowComponent component = base.Entity.GetComponent<CharacterFollowComponent>();
		Entity entity = (component != null) ? component.GetAttributeHolder() : null;
		CharacterBuffComponent characterBuffComponent = (entity != null) ? entity.GetComponent<CharacterBuffComponent>() : null;
		if (characterBuffComponent != null && characterBuffComponent != this)
		{
			characterBuffComponent.AddBuff(buffId, buffParams);
			return;
		}
		CombatLog instance = Singleton<CombatLog>.Instance;
		CombatLog.EDebugModule flag = CombatLog.EDebugModule.Buff;
		Entity entity2 = base.Entity;
		string message = "添加幻象buff时无法获取到合法的召唤者";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("buffId", buffId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("reason", (buffParams != null) ? buffParams.Reason : null);
		instance.Error(flag, entity2, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
	}

	// Token: 0x06018FDB RID: 102363 RVA: 0x00716148 File Offset: 0x00714348
	public unsafe override void RemoveBuff(long buffId, int stackCount, string reason, long? preMessageId = null, bool? isServerRequest = null, long? instigatorId = null)
	{
		if (this.NeedTransfer())
		{
			CharacterFollowComponent component = base.Entity.GetComponent<CharacterFollowComponent>();
			Entity entity = (component != null) ? component.GetAttributeHolder() : null;
			CharacterBuffComponent characterBuffComponent = (entity != null) ? entity.GetComponent<CharacterBuffComponent>() : null;
			if (characterBuffComponent != null && characterBuffComponent != this)
			{
				characterBuffComponent.RemoveBuff(buffId, stackCount, reason, preMessageId, isServerRequest, instigatorId);
			}
			else
			{
				CombatLog instance = Singleton<CombatLog>.Instance;
				CombatLog.EDebugModule flag = CombatLog.EDebugModule.Buff;
				Entity entity2 = base.Entity;
				string message = "移除幻象buff时无法获取到合法的召唤者";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("buffId", buffId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("reason", reason);
				instance.Error(flag, entity2, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
		}
		base.RemoveBuff(buffId, stackCount, reason, preMessageId, isServerRequest, instigatorId);
	}

	// Token: 0x06018FDC RID: 102364 RVA: 0x00716208 File Offset: 0x00714408
	[NullableContext(2)]
	public override BaseBuffComponent GetBuffApplyTarget(long buffId, long instigatorId)
	{
		if (base.CreatureDataId == instigatorId || !this.NeedTransfer())
		{
			return this;
		}
		CharacterFollowComponent component = base.Entity.GetComponent<CharacterFollowComponent>();
		Entity entity = (component != null) ? component.GetAttributeHolder() : null;
		CharacterBuffComponent characterBuffComponent = (entity != null) ? entity.GetComponent<CharacterBuffComponent>() : null;
		if (characterBuffComponent != null && characterBuffComponent != this)
		{
			return characterBuffComponent.GetBuffApplyTarget(buffId, instigatorId);
		}
		return null;
	}

	// Token: 0x06018FDD RID: 102365 RVA: 0x00716260 File Offset: 0x00714460
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		VisionBuffComponent visionBuffComponent = (VisionBuffComponent)componentTemplate;
		if (base.CanResetComponentProperty("NeedNeedTransferFlag"))
		{
			this.NeedNeedTransferFlag = visionBuffComponent.NeedNeedTransferFlag;
		}
		return true;
	}

	// Token: 0x0400C353 RID: 50003
	private bool? NeedNeedTransferFlag;
}
