using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006C0A RID: 27658
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelEventSportsState : LevelEventBase
	{
		// Token: 0x06044164 RID: 278884 RVA: 0x011AD509 File Offset: 0x011AB709
		public LevelEventSportsState(int id) : base(id)
		{
		}

		// Token: 0x06044165 RID: 278885 RVA: 0x011AD514 File Offset: 0x011AB714
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			if (inParams == null)
			{
				base.FinishExecute(false, false, true);
				return;
			}
			ISportConfig config = (inParams as SetSportsState).Config;
			ESportStateType type = config.Type;
			if (type == ESportStateType.Slide)
			{
				CharacterSlideComponent.SetSlideConfig((config as ISlideConfig).SlideId);
				return;
			}
			if (type != ESportStateType.Ski)
			{
				return;
			}
			ISkiConfig skiConfig = config as ISkiConfig;
			switch (skiConfig.Config.Type)
			{
			case ESkiConfig.Open:
				this.EnterSkiMode(skiConfig.Config as IOpenSkiConfig, context);
				return;
			case ESkiConfig.Close:
				this.ExitSkiMode(skiConfig.Config as ICloseSkiConfig, context);
				return;
			case ESkiConfig.Accelerate:
				this.SetSkiAccel(skiConfig.Config as IAccelerateSkiConfig, context);
				return;
			default:
				return;
			}
		}

		// Token: 0x06044166 RID: 278886 RVA: 0x011AD5B8 File Offset: 0x011AB7B8
		private unsafe void EnterSkiMode(IOpenSkiConfig config, GeneralContext context)
		{
			EGeneralContextType? type = context.Type;
			if (type != null)
			{
				EGeneralContextType valueOrDefault = type.GetValueOrDefault();
				if (valueOrDefault == EGeneralContextType.Entity || valueOrDefault - EGeneralContextType.Trigger <= 1)
				{
					Entity entity = null;
					string text = this.ParseSource(context);
					if (config.Target.Type == ETargetEntityType.Player)
					{
						TsBaseCharacter baseCharacter = Global.BaseCharacter;
						entity = ((baseCharacter != null) ? baseCharacter.GetEntityNoBlueprint() : null);
					}
					if (entity == null)
					{
						global::Log instance = Singleton<global::Log>.Instance;
						ELogModule module = ELogModule.LevelEvent;
						ELogAuthor author = ELogAuthor.YJX;
						string message = "目前仅Role支持触发滑雪模式";
						<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ContextType", context.Type);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ContextSource", text);
						instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
						return;
					}
					bool flag = text == "180700235";
					global::Log instance2 = Singleton<global::Log>.Instance;
					ELogModule module2 = ELogModule.LevelEvent;
					ELogAuthor author2 = ELogAuthor.YJX;
					string message2 = "进入滑雪模式";
					<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("Type", context.Type);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("ContextSource", text);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("NeedSetBase", flag);
					instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
					CharacterSlideComponent component = entity.GetComponent<CharacterSlideComponent>();
					if (component == null)
					{
						return;
					}
					component.EnterSkiMode(config, flag);
					return;
				}
			}
			global::Log instance3 = Singleton<global::Log>.Instance;
			ELogModule module3 = ELogModule.LevelEvent;
			ELogAuthor author3 = ELogAuthor.LCZ;
			string message3 = "LevelEventSportsState Ski: 类型必须对应GeneralLogicTreeContext | Entity | Trigger";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ContextType", context.Type);
			instance3.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x06044167 RID: 278887 RVA: 0x011AD740 File Offset: 0x011AB940
		private unsafe void ExitSkiMode(ICloseSkiConfig config, GeneralContext context)
		{
			EGeneralContextType? type = context.Type;
			if (type != null)
			{
				switch (type.GetValueOrDefault())
				{
				case EGeneralContextType.Entity:
				case EGeneralContextType.LevelPlay:
				case EGeneralContextType.Trigger:
				case EGeneralContextType.GeneralLogicTree:
				{
					Entity entity = null;
					string item = this.ParseSource(context);
					if (config.Target.Type == ETargetEntityType.Player)
					{
						TsBaseCharacter baseCharacter = Global.BaseCharacter;
						entity = ((baseCharacter != null) ? baseCharacter.GetEntityNoBlueprint() : null);
					}
					if (entity == null)
					{
						global::Log instance = Singleton<global::Log>.Instance;
						ELogModule module = ELogModule.LevelEvent;
						ELogAuthor author = ELogAuthor.YJX;
						string message = "目前仅Role支持关闭滑雪模式";
						<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ContextType", context.Type);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ContextSource", item);
						instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
						return;
					}
					global::Log instance2 = Singleton<global::Log>.Instance;
					ELogModule module2 = ELogModule.LevelEvent;
					ELogAuthor author2 = ELogAuthor.YJX;
					string message2 = "退出滑雪模式";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("Type", context.Type);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("ContextSource", item);
					instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
					CharacterSlideComponent component = entity.GetComponent<CharacterSlideComponent>();
					if (component == null)
					{
						return;
					}
					component.ExitSkiMode(true);
					return;
				}
				}
			}
			global::Log instance3 = Singleton<global::Log>.Instance;
			ELogModule module3 = ELogModule.LevelEvent;
			ELogAuthor author3 = ELogAuthor.LCZ;
			string message3 = "LevelEventSportsState Ski: 类型必须对应GeneralLogicTreeContext | Entity | LevelPlay | Trigger";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ContextType", context.Type);
			instance3.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x06044168 RID: 278888 RVA: 0x011AD8B4 File Offset: 0x011ABAB4
		private void SetSkiAccel(IAccelerateSkiConfig config, GeneralContext context)
		{
			if (!(context is TriggerContext))
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.LevelEvent;
				ELogAuthor author = ELogAuthor.LCZ;
				string message = "LevelEventSportsState Ski: Triggered类型必须对应TriggerContext";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ContextType", context.Type);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			TriggerContext triggerContext = context as TriggerContext;
			CharacterSlideComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterSlideComponent>(triggerContext.OtherEntityId.Value);
			if (component == null)
			{
				return;
			}
			component.SetSkiAccel(config);
		}

		// Token: 0x06044169 RID: 278889 RVA: 0x011AD924 File Offset: 0x011ABB24
		private string ParseSource(GeneralContext inContext)
		{
			string result = "";
			EGeneralContextType? type = inContext.Type;
			if (type != null)
			{
				switch (type.GetValueOrDefault())
				{
				case EGeneralContextType.Entity:
				{
					CreatureDataComponent component = Singleton<EntitySystem>.Instance.GetComponent<CreatureDataComponent>((inContext as EntityContext).EntityId.Value);
					result = (((component != null) ? component.GetPbDataId().ToString() : null) ?? "");
					break;
				}
				case EGeneralContextType.LevelPlay:
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(10, 1);
					defaultInterpolatedStringHandler.AppendLiteral("LevelPlay:");
					defaultInterpolatedStringHandler.AppendFormatted<int>((inContext as LevelPlayContext).LevelPlayId);
					result = defaultInterpolatedStringHandler.ToStringAndClear();
					break;
				}
				case EGeneralContextType.Trigger:
				{
					CreatureDataComponent component2 = Singleton<EntitySystem>.Instance.GetComponent<CreatureDataComponent>((inContext as TriggerContext).TriggerEntityId.Value);
					result = (((component2 != null) ? component2.GetPbDataId().ToString() : null) ?? "");
					break;
				}
				case EGeneralContextType.GeneralLogicTree:
				{
					GeneralLogicTreeContext generalLogicTreeContext = inContext as GeneralLogicTreeContext;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
					defaultInterpolatedStringHandler.AppendFormatted<int>(generalLogicTreeContext.TreeConfigId);
					defaultInterpolatedStringHandler.AppendLiteral("/");
					defaultInterpolatedStringHandler.AppendFormatted<int>(generalLogicTreeContext.NodeId);
					result = defaultInterpolatedStringHandler.ToStringAndClear();
					break;
				}
				}
			}
			return result;
		}
	}
}
