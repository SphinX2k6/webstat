using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.WuwaGo
{
	// Token: 0x02004AB5 RID: 19125
	[NullableContext(1)]
	[Nullable(0)]
	public class WuWaGoFactory : IStaticVariableResetter
	{
		// Token: 0x06031DA6 RID: 204198 RVA: 0x00C79BAC File Offset: 0x00C77DAC
		static WuWaGoFactory()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(WuWaGoFactory.CreateStaticDefaultValue), new Action(WuWaGoFactory.ResetStaticDefaultValue));
		}

		// Token: 0x06031DA7 RID: 204199 RVA: 0x00C79BCB File Offset: 0x00C77DCB
		public static void CreateStaticDefaultValue()
		{
			WuWaGoFactory._attackHitListeners = new Dictionary<AActor, Action>();
		}

		// Token: 0x06031DA8 RID: 204200 RVA: 0x00C79BD7 File Offset: 0x00C77DD7
		public static void ResetStaticDefaultValue()
		{
			WuWaGoFactory._attackHitListeners = null;
		}

		// Token: 0x06031DA9 RID: 204201 RVA: 0x00C79BDF File Offset: 0x00C77DDF
		public static void RegisterAttackHitListener([Nullable(2)] AActor actor, Action listener)
		{
			if (actor == null || !actor.IsValid())
			{
				return;
			}
			WuWaGoFactory._attackHitListeners[actor] = listener;
		}

		// Token: 0x06031DAA RID: 204202 RVA: 0x00C79BFF File Offset: 0x00C77DFF
		[NullableContext(2)]
		public static void UnregisterAttackHitListener(AActor actor)
		{
			if (actor == null || !actor.IsValid())
			{
				return;
			}
			Dictionary<AActor, Action> attackHitListeners = WuWaGoFactory._attackHitListeners;
			if (attackHitListeners == null)
			{
				return;
			}
			attackHitListeners.Remove(actor);
		}

		// Token: 0x06031DAB RID: 204203 RVA: 0x00C79C24 File Offset: 0x00C77E24
		[NullableContext(2)]
		public static void DispatchAttackHit(AActor actor)
		{
			if (actor == null || !actor.IsValid())
			{
				return;
			}
			Action action;
			if (WuWaGoFactory._attackHitListeners != null && WuWaGoFactory._attackHitListeners.TryGetValue(actor, out action))
			{
				action();
			}
		}

		// Token: 0x06031DAC RID: 204204 RVA: 0x00C79C60 File Offset: 0x00C77E60
		[return: Nullable(new byte[]
		{
			0,
			2
		})]
		public static UniTask<TsBaseCharacter> CreateRole(EWuWaGoRoleType type, Vector position, Rotator rotator)
		{
			WuWaGoFactory.<CreateRole>d__7 <CreateRole>d__;
			<CreateRole>d__.<>t__builder = AsyncUniTaskMethodBuilder<TsBaseCharacter>.Create();
			<CreateRole>d__.type = type;
			<CreateRole>d__.position = position;
			<CreateRole>d__.rotator = rotator;
			<CreateRole>d__.<>1__state = -1;
			<CreateRole>d__.<>t__builder.Start<WuWaGoFactory.<CreateRole>d__7>(ref <CreateRole>d__);
			return <CreateRole>d__.<>t__builder.Task;
		}

		// Token: 0x06031DAD RID: 204205 RVA: 0x00C79CB3 File Offset: 0x00C77EB3
		public static bool DestroyRole(AActor actor)
		{
			CharRenderingComponent charRenderingComponent = ((TsBaseCharacter)actor).CharRenderingComponent;
			if (charRenderingComponent != null)
			{
				charRenderingComponent.Destroy();
			}
			return Singleton<ActorSystem>.Instance.Put("WuWaGoFactory.DestroyRole", actor, null);
		}

		// Token: 0x06031DAE RID: 204206 RVA: 0x00C79CDC File Offset: 0x00C77EDC
		[return: Nullable(new byte[]
		{
			0,
			2
		})]
		public static UniTask<AActor> CreateGridLinkApplique(EWuWaGoGridLinkType gridLinkType, Vector position, Rotator rotator, [Nullable(2)] UStaticMesh mesh)
		{
			WuWaGoFactory.<CreateGridLinkApplique>d__9 <CreateGridLinkApplique>d__;
			<CreateGridLinkApplique>d__.<>t__builder = AsyncUniTaskMethodBuilder<AActor>.Create();
			<CreateGridLinkApplique>d__.gridLinkType = gridLinkType;
			<CreateGridLinkApplique>d__.position = position;
			<CreateGridLinkApplique>d__.rotator = rotator;
			<CreateGridLinkApplique>d__.mesh = mesh;
			<CreateGridLinkApplique>d__.<>1__state = -1;
			<CreateGridLinkApplique>d__.<>t__builder.Start<WuWaGoFactory.<CreateGridLinkApplique>d__9>(ref <CreateGridLinkApplique>d__);
			return <CreateGridLinkApplique>d__.<>t__builder.Task;
		}

		// Token: 0x06031DAF RID: 204207 RVA: 0x00C79D38 File Offset: 0x00C77F38
		[return: Nullable(new byte[]
		{
			0,
			2
		})]
		public static UniTask<AActor> CreateCanMoveTipsApplique(Vector position, Rotator rotator, [Nullable(2)] UStaticMesh mesh)
		{
			WuWaGoFactory.<CreateCanMoveTipsApplique>d__10 <CreateCanMoveTipsApplique>d__;
			<CreateCanMoveTipsApplique>d__.<>t__builder = AsyncUniTaskMethodBuilder<AActor>.Create();
			<CreateCanMoveTipsApplique>d__.position = position;
			<CreateCanMoveTipsApplique>d__.rotator = rotator;
			<CreateCanMoveTipsApplique>d__.mesh = mesh;
			<CreateCanMoveTipsApplique>d__.<>1__state = -1;
			<CreateCanMoveTipsApplique>d__.<>t__builder.Start<WuWaGoFactory.<CreateCanMoveTipsApplique>d__10>(ref <CreateCanMoveTipsApplique>d__);
			return <CreateCanMoveTipsApplique>d__.<>t__builder.Task;
		}

		// Token: 0x06031DB0 RID: 204208 RVA: 0x00C79D8C File Offset: 0x00C77F8C
		[return: Nullable(new byte[]
		{
			0,
			2
		})]
		private static UniTask<AActor> CreateApplique(string materialPath, Vector position, Rotator rotator, [Nullable(2)] UStaticMesh mesh)
		{
			WuWaGoFactory.<CreateApplique>d__11 <CreateApplique>d__;
			<CreateApplique>d__.<>t__builder = AsyncUniTaskMethodBuilder<AActor>.Create();
			<CreateApplique>d__.materialPath = materialPath;
			<CreateApplique>d__.position = position;
			<CreateApplique>d__.rotator = rotator;
			<CreateApplique>d__.mesh = mesh;
			<CreateApplique>d__.<>1__state = -1;
			<CreateApplique>d__.<>t__builder.Start<WuWaGoFactory.<CreateApplique>d__11>(ref <CreateApplique>d__);
			return <CreateApplique>d__.<>t__builder.Task;
		}

		// Token: 0x06031DB1 RID: 204209 RVA: 0x00C79DE7 File Offset: 0x00C77FE7
		public static bool DestroyApplique(AActor actor)
		{
			return Singleton<ActorSystem>.Instance.Put("WuWaGoFactory.DestroyApplique", actor, null);
		}

		// Token: 0x0401D2FC RID: 119548
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private static Dictionary<AActor, Action> _attackHitListeners;
	}
}
