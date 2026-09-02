using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.SimpleGameplay
{
	// Token: 0x02006C32 RID: 27698
	[NullableContext(1)]
	[Nullable(0)]
	public class SimpleGameplayHandlerMap<[Nullable(0)] THandler> where THandler : ISimpleGameplayHandlerBase
	{
		// Token: 0x060441E6 RID: 279014 RVA: 0x011B0B2C File Offset: 0x011AED2C
		public unsafe void Register(THandler handler)
		{
			ESimpleGameplayType type = handler.Type;
			THandler thandler;
			if (this.Handlers.TryGetValue(type, out thandler) && thandler != handler)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.SceneGameplay;
				ELogAuthor author = ELogAuthor.XDW;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(54, 1);
				defaultInterpolatedStringHandler.AppendLiteral("[SimpleGameplayHandlerRegistry] 重复注册 Handler: ");
				defaultInterpolatedStringHandler.AppendFormatted<ESimpleGameplayType>(type);
				defaultInterpolatedStringHandler.AppendLiteral(", 后者覆盖前者");
				string message = defaultInterpolatedStringHandler.ToStringAndClear();
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("exist", thandler);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("new", handler);
				instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
			this.Handlers[type] = handler;
		}

		// Token: 0x060441E7 RID: 279015 RVA: 0x011B0C01 File Offset: 0x011AEE01
		[NullableContext(2)]
		public THandler Get(ESimpleGameplayType type)
		{
			return this.Handlers.GetValueOrDefault(type);
		}

		// Token: 0x060441E8 RID: 279016 RVA: 0x011B0C0F File Offset: 0x011AEE0F
		public void Unregister(ESimpleGameplayType type)
		{
			this.Handlers.Remove(type);
		}

		// Token: 0x060441E9 RID: 279017 RVA: 0x011B0C1E File Offset: 0x011AEE1E
		public List<ESimpleGameplayType> GetAllRegisteredTypes()
		{
			return new List<ESimpleGameplayType>(this.Handlers.Keys);
		}

		// Token: 0x040260A4 RID: 155812
		private readonly Dictionary<ESimpleGameplayType, THandler> Handlers = new Dictionary<ESimpleGameplayType, THandler>();
	}
}
