using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.LevelGamePlay.LevelEvents.SimpleGameplay.Handlers;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.SimpleGameplay
{
	// Token: 0x02006C33 RID: 27699
	public class SimpleGameplayHandlerRegistry : IStaticVariableResetter
	{
		// Token: 0x060441EB RID: 279019 RVA: 0x011B0C43 File Offset: 0x011AEE43
		private static void RegisterAllGenerated()
		{
			SimpleGameplayHandlerRegistry.Open.Register(new DragActorOpenHandler());
		}

		// Token: 0x060441EC RID: 279020 RVA: 0x011B0C54 File Offset: 0x011AEE54
		static SimpleGameplayHandlerRegistry()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(SimpleGameplayHandlerRegistry.CreateStaticDefaultValue), new Action(SimpleGameplayHandlerRegistry.ResetStaticDefaultValue));
		}

		// Token: 0x060441ED RID: 279021 RVA: 0x011B0C73 File Offset: 0x011AEE73
		public static void CreateStaticDefaultValue()
		{
			SimpleGameplayHandlerRegistry.Open = new SimpleGameplayHandlerMap<ISimpleGameplayOpenHandler>();
			SimpleGameplayHandlerRegistry.RegisterAllGenerated();
		}

		// Token: 0x060441EE RID: 279022 RVA: 0x011B0C84 File Offset: 0x011AEE84
		public static void ResetStaticDefaultValue()
		{
			SimpleGameplayHandlerRegistry.Open = null;
		}

		// Token: 0x060441EF RID: 279023 RVA: 0x011B0C8C File Offset: 0x011AEE8C
		[NullableContext(1)]
		public static void RegisterOpen<[Nullable(0)] TConfig>(ISimpleGameplayOpenHandler<TConfig> handler) where TConfig : IUiGame
		{
			SimpleGameplayHandlerMap<ISimpleGameplayOpenHandler> open = SimpleGameplayHandlerRegistry.Open;
			if (open == null)
			{
				return;
			}
			open.Register(handler);
		}

		// Token: 0x040260A5 RID: 155813
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public static SimpleGameplayHandlerMap<ISimpleGameplayOpenHandler> Open;
	}
}
