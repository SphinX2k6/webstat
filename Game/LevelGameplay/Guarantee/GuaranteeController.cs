using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay.Guarantee.GuaranteeActions;

namespace CSharpScript.Game.LevelGamePlay.Guarantee
{
	// Token: 0x02006E62 RID: 28258
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class GuaranteeController : ControllerBase<GuaranteeController>
	{
		// Token: 0x06044954 RID: 280916 RVA: 0x011D4638 File Offset: 0x011D2838
		protected override bool OnInit()
		{
			Singleton<EventSystem>.Instance.Add<string, GeneralContext, GuaranteeActionInfo, bool?>(EEventName.AddGuaranteeAction, new Action<string, GeneralContext, GuaranteeActionInfo, bool?>(this.AddGuaranteeAction));
			Singleton<EventSystem>.Instance.Add<string, GeneralContext, GuaranteeActionInfo, bool?>(EEventName.RemGuaranteeAction, new Action<string, GeneralContext, GuaranteeActionInfo, bool?>(this.RemGuaranteeAction));
			Singleton<EventSystem>.Instance.Add(EEventName.ClearWorld, new Action(this.ExecSceneGuaranteeActions));
			return true;
		}

		// Token: 0x06044955 RID: 280917 RVA: 0x011D469C File Offset: 0x011D289C
		protected override bool OnClear()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.AddGuaranteeAction, new <>f__AnonymousDelegate1<string, GeneralContext, GuaranteeActionInfo, bool?>(this.AddGuaranteeAction));
			Singleton<EventSystem>.Instance.Remove(EEventName.RemGuaranteeAction, new <>f__AnonymousDelegate1<string, GeneralContext, GuaranteeActionInfo, bool?>(this.RemGuaranteeAction));
			Singleton<EventSystem>.Instance.Remove(EEventName.ClearWorld, new Action(this.ExecSceneGuaranteeActions));
			LevelGeneralModel instance = ModelBase<LevelGeneralModel>.Instance;
			Dictionary<EntityHandle, List<GuaranteeActionInfo>> dictionary = (instance != null) ? instance.GetEntityGuaranteeActionInfos() : null;
			if (dictionary != null)
			{
				foreach (EntityHandle entityHandle in dictionary.Keys)
				{
					if (entityHandle != null && entityHandle.Valid && Singleton<EventSystem>.Instance.HasWithTarget(entityHandle, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.ExecEntityGuaranteeActions)))
					{
						Singleton<EventSystem>.Instance.RemoveWithTarget(entityHandle, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.ExecEntityGuaranteeActions));
					}
				}
				LevelGeneralModel instance2 = ModelBase<LevelGeneralModel>.Instance;
				if (instance2 != null)
				{
					instance2.ClearEntityGuaranteeActionInfos();
				}
			}
			return true;
		}

		// Token: 0x06044956 RID: 280918 RVA: 0x011D47AC File Offset: 0x011D29AC
		public void ExecSceneGuaranteeActions()
		{
			LevelGeneralModel instance = ModelBase<LevelGeneralModel>.Instance;
			List<GuaranteeActionInfo> list = (instance != null) ? instance.RemoveSceneGuaranteeActionInfos() : null;
			if (list != null && list.Count > 0)
			{
				list.Reverse();
				List<GuaranteeActionInfo> list2 = list;
				this.ExecuteActions(list2, GuaranteeContext.Create(null, EGuaranteeReason.Unknown));
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module = ELogModule.LevelEvent;
				ELogAuthor author = ELogAuthor.ZYL;
				string message = "场景保底行为已全部完成";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("保底行为列表", list2);
				instance2.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
		}

		// Token: 0x06044957 RID: 280919 RVA: 0x011D481C File Offset: 0x011D2A1C
		public void ExecEntityGuaranteeActions(ERemoveEntityType removeType, EntityHandle handle)
		{
			LevelGeneralModel instance = ModelBase<LevelGeneralModel>.Instance;
			List<GuaranteeActionInfo> list = (instance != null) ? instance.RemoveEntityGuaranteeActionInfos(handle) : null;
			if (handle != null && handle.Valid && Singleton<EventSystem>.Instance.HasWithTarget(handle, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.ExecEntityGuaranteeActions)))
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget(handle, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.ExecEntityGuaranteeActions));
			}
			if (list != null && list.Count > 0)
			{
				list.Reverse();
				List<GuaranteeActionInfo> actionInfos = list;
				this.ExecuteActions(actionInfos, GuaranteeContext.Create(null, EGuaranteeReason.Unknown));
			}
		}

		// Token: 0x06044958 RID: 280920 RVA: 0x011D48AC File Offset: 0x011D2AAC
		private void AddGuaranteeAction(string instigatorName, [Nullable(2)] GeneralContext instigatorContext, GuaranteeActionInfo guaranteeActionInfo, bool? bNeedGuaranteeInQuest = false)
		{
			this.UpdateGuaranteeActions(instigatorName, instigatorContext, true, guaranteeActionInfo, bNeedGuaranteeInQuest.GetValueOrDefault());
		}

		// Token: 0x06044959 RID: 280921 RVA: 0x011D48BF File Offset: 0x011D2ABF
		private void RemGuaranteeAction(string instigatorName, [Nullable(2)] GeneralContext instigatorContext, GuaranteeActionInfo guaranteeActionInfo, bool? bNeedGuaranteeInQuest = false)
		{
			this.UpdateGuaranteeActions(instigatorName, instigatorContext, false, guaranteeActionInfo, bNeedGuaranteeInQuest.GetValueOrDefault());
		}

		// Token: 0x0604495A RID: 280922 RVA: 0x011D48D4 File Offset: 0x011D2AD4
		private unsafe void UpdateGuaranteeActions(string instigatorName, [Nullable(2)] GeneralContext instigatorContext, bool isAdd, GuaranteeActionInfo guaranteeActionInfo, bool bNeedGuaranteeInQuest)
		{
			if (instigatorContext == null || instigatorContext.Type.GetValueOrDefault() == EGeneralContextType.Guarantee)
			{
				return;
			}
			if (guaranteeActionInfo == null)
			{
				return;
			}
			EGuaranteeAction name = guaranteeActionInfo.Name;
			if (instigatorContext.Type.GetValueOrDefault() != EGeneralContextType.Entity)
			{
				EActionFilterMode actionFilterMode = Singleton<GuaranteeActionCenter>.Instance.GetActionFilterMode(guaranteeActionInfo.Name);
				LevelGeneralModel instance = ModelBase<LevelGeneralModel>.Instance;
				if (isAdd)
				{
					if (!instance.HasSceneGuaranteeActionInfo(guaranteeActionInfo, actionFilterMode))
					{
						instance.AddSceneGuaranteeActionInfo(guaranteeActionInfo);
						Log instance2 = Singleton<Log>.Instance;
						ELogModule module = ELogModule.LevelEvent;
						ELogAuthor author = ELogAuthor.ZYL;
						DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(9, 1);
						defaultInterpolatedStringHandler.AppendLiteral("添加场景保底行为：");
						defaultInterpolatedStringHandler.AppendFormatted<EGuaranteeAction>(guaranteeActionInfo.Name);
						string message = defaultInterpolatedStringHandler.ToStringAndClear();
						<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("触发行为", instigatorName);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ActionInfo", guaranteeActionInfo);
						instance2.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
						return;
					}
				}
				else
				{
					instance.PopSceneGuaranteeActionInfo(guaranteeActionInfo);
					Log instance3 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.LevelEvent;
					ELogAuthor author2 = ELogAuthor.ZYL;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(9, 1);
					defaultInterpolatedStringHandler.AppendLiteral("移除场景保底行为：");
					defaultInterpolatedStringHandler.AppendFormatted<EGuaranteeAction>(guaranteeActionInfo.Name);
					string message2 = defaultInterpolatedStringHandler.ToStringAndClear();
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("触发行为", instigatorName);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("ActionInfo", guaranteeActionInfo);
					instance3.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
				}
				return;
			}
			EntityContext entityContext = instigatorContext as EntityContext;
			if (entityContext == null || entityContext.EntityId == null)
			{
				return;
			}
			EActionFilterMode actionFilterMode2 = Singleton<GuaranteeActionCenter>.Instance.GetActionFilterMode(guaranteeActionInfo.Name);
			LevelGeneralModel instance4 = ModelBase<LevelGeneralModel>.Instance;
			if (isAdd)
			{
				if (!instance4.HasEntityGuaranteeActionInfo(entityContext.EntityId, guaranteeActionInfo, actionFilterMode2))
				{
					instance4.AddEntityGuaranteeActionInfo(entityContext.EntityId, guaranteeActionInfo);
					EntityHandle handle = ModelBase<CharacterModel>.Instance.GetHandle(entityContext.EntityId.GetValueOrDefault());
					if (handle != null && handle.Valid && !Singleton<EventSystem>.Instance.HasWithTarget(handle, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.ExecEntityGuaranteeActions)))
					{
						Singleton<EventSystem>.Instance.AddWithTarget<ERemoveEntityType, EntityHandle>(handle, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.ExecEntityGuaranteeActions));
						return;
					}
				}
			}
			else
			{
				EntityHandle handle2 = ModelBase<CharacterModel>.Instance.GetHandle(entityContext.EntityId.GetValueOrDefault());
				if (handle2 != null && handle2.Valid && Singleton<EventSystem>.Instance.HasWithTarget(handle2, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.ExecEntityGuaranteeActions)))
				{
					Singleton<EventSystem>.Instance.RemoveWithTarget(handle2, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.ExecEntityGuaranteeActions));
				}
				instance4.PopEntityGuaranteeActionInfo(entityContext.EntityId, guaranteeActionInfo);
			}
		}

		// Token: 0x0604495B RID: 280923 RVA: 0x011D4B88 File Offset: 0x011D2D88
		public unsafe void ExecuteActions(List<GuaranteeActionInfo> actionInfos, GuaranteeContext context)
		{
			if (context == null)
			{
				return;
			}
			foreach (GuaranteeActionInfo guaranteeActionInfo in actionInfos)
			{
				EGuaranteeAction name = guaranteeActionInfo.Name;
				GuaranteeActionBase guaranteeAction = Singleton<GuaranteeActionCenter>.Instance.GetGuaranteeAction(name);
				if (guaranteeAction != null)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.LevelEvent;
					ELogAuthor author = ELogAuthor.ZYL;
					string message = "执行保底行为：";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("actionName", name);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ActionInfo", guaranteeActionInfo);
					instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					guaranteeAction.Execute(guaranteeActionInfo, context);
				}
			}
		}
	}
}
