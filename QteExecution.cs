using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Fight.Struct;

// Token: 0x02002F7D RID: 12157
[NullableContext(1)]
[Nullable(0)]
public class QteExecution : InitExecution
{
	// Token: 0x06018D28 RID: 101672 RVA: 0x00705A67 File Offset: 0x00703C67
	public QteExecution(RequireAndLimits requireAndLimits) : base(requireAndLimits)
	{
	}

	// Token: 0x06018D29 RID: 101673 RVA: 0x00705A70 File Offset: 0x00703C70
	protected override void InitParameters(ExtraEffectParameters parameters)
	{
		string[] extraEffectParameters_ = parameters.ExtraEffectParameters_;
		this.NeedEnergy = ((extraEffectParameters_ != null && extraEffectParameters_.Length != 0) ? float.Parse(extraEffectParameters_[0]) : 0f);
		if (extraEffectParameters_ != null && extraEffectParameters_.Length > 1 && !string.IsNullOrEmpty(extraEffectParameters_[1]))
		{
			this.AllowChangeRole = (int.Parse(extraEffectParameters_[1]) > 0);
		}
	}

	// Token: 0x06018D2A RID: 101674 RVA: 0x00705AC4 File Offset: 0x00703CC4
	[return: Nullable(2)]
	public unsafe override object OnExecute(params object[] args)
	{
		Entity ownerEntity = base.OwnerEntity;
		if (ownerEntity == null || !ownerEntity.Valid || !ownerEntity.IsInit)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Battle;
			ELogAuthor author = ELogAuthor.LYY;
			string message = "执行Qte额外效果时，Buff持有者不合法";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("buffId", this.BuffId);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
			string item = "持有者";
			IBuffComponent ownerBuffComponent = this.OwnerBuffComponent;
			ptr = new ValueTuple<string, object>(item, (ownerBuffComponent != null) ? ownerBuffComponent.GetDebugName() : null);
			instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return null;
		}
		int id = ownerEntity.Id;
		SceneTeamItem teamItem = ModelBase<SceneTeamModel>.Instance.GetTeamItem((long)id, new GetTeamItemOptions
		{
			ParamType = ETeamParamType.EntityId
		});
		if (teamItem == null || !teamItem.IsMyRole())
		{
			return null;
		}
		EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
		WorldEntity worldEntity = (getCurrentEntity != null) ? getCurrentEntity.Entity : null;
		if (worldEntity == null || !worldEntity.Valid || !worldEntity.IsInit)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Battle;
			ELogAuthor author2 = ELogAuthor.LYY;
			string message2 = "执行Qte额外效果时，编队当前角色不合法";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("buffId", this.BuffId);
			ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1);
			string item2 = "持有者";
			IBuffComponent ownerBuffComponent2 = this.OwnerBuffComponent;
			ptr2 = new ValueTuple<string, object>(item2, (ownerBuffComponent2 != null) ? ownerBuffComponent2.GetDebugName() : null);
			instance2.Warn(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			return null;
		}
		if (id == worldEntity.Id)
		{
			return null;
		}
		RoleQteComponent component = ownerEntity.GetComponent<RoleQteComponent>();
		SQteTag sqteTag = (component != null) ? component.GetQteTagData() : null;
		if (sqteTag == null)
		{
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.Battle;
			ELogAuthor author3 = ELogAuthor.LYY;
			string message3 = "执行Qte额外效果时，Buff持有者无Qte配置";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("buffId", this.BuffId);
			ref ValueTuple<string, object> ptr3 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1);
			string item3 = "持有者";
			IBuffComponent ownerBuffComponent3 = this.OwnerBuffComponent;
			ptr3 = new ValueTuple<string, object>(item3, (ownerBuffComponent3 != null) ? ownerBuffComponent3.GetDebugName() : null);
			instance3.Warn(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 2));
			return null;
		}
		if (!this.AllowChangeRole && (sqteTag.ChangeRole || sqteTag.ChangeRoleOnQte))
		{
			return null;
		}
		bool flag = this.NeedEnergy > 0f;
		BaseTagComponent component2 = worldEntity.GetComponent<BaseTagComponent>();
		if (component2 == null)
		{
			return null;
		}
		if (!flag)
		{
			component2.TagContainer.UpdateExactTag(ETagChannel.BattleBuff, GameplayTagDefine.EGameplayTagId["功能.功能制作.QTE.激活QTE.不消耗能量"], 1);
		}
		try
		{
			ControllerBase<CooperationController>.Instance.TryCooperate(teamItem.GetCreatureDataId());
		}
		catch (Exception ex)
		{
			Log instance4 = Singleton<Log>.Instance;
			ELogModule module4 = ELogModule.Battle;
			ELogAuthor author4 = ELogAuthor.LYY;
			string message4 = "执行Qte额外效果出现异常";
			Exception error = ex;
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray4 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 0) = new ValueTuple<string, object>("CreatureDataId", teamItem.GetCreatureDataId());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 1) = new ValueTuple<string, object>("Error", ex.Message);
			instance4.ErrorWithStack(module4, author4, message4, error, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray4, 2));
		}
		if (!flag)
		{
			component2.TagContainer.UpdateExactTag(ETagChannel.BattleBuff, GameplayTagDefine.EGameplayTagId["功能.功能制作.QTE.激活QTE.不消耗能量"], -1);
		}
		return null;
	}

	// Token: 0x0400C1A1 RID: 49569
	private float NeedEnergy;

	// Token: 0x0400C1A2 RID: 49570
	private bool AllowChangeRole;
}
