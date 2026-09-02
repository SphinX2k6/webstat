using System;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using UnrealEngine;

namespace CSharpScript.Core.Model
{
	// Token: 0x02007124 RID: 28964
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class JsModelManager : Singleton<JsModelManager>
	{
		// Token: 0x06046273 RID: 287347 RVA: 0x0126C884 File Offset: 0x0126AA84
		public void InitializeEnvironment()
		{
			UWorld world = Singleton<Info>.Instance.World;
			if (world == null)
			{
				Singleton<Log>.Instance.Info(ELogModule.Core, ELogAuthor.WLJ, "JsModelManager.InitializeEnvironment Fail!!!", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			UKuroJsModelFunctionLibrary.InitializeEnvironment(world);
			this.HasInitialized = true;
		}

		// Token: 0x06046274 RID: 287348 RVA: 0x0126C8C8 File Offset: 0x0126AAC8
		public void DestroyEnvironment()
		{
			this.HasInitialized = false;
			UKuroJsModelFunctionLibrary.DestroyEnvironment();
		}

		// Token: 0x06046275 RID: 287349 RVA: 0x0126C8D6 File Offset: 0x0126AAD6
		public void AddEntity(int entityId)
		{
			if (!this.HasInitialized)
			{
				return;
			}
			UKuroJsModelFunctionLibrary.AddEntity(entityId);
		}

		// Token: 0x06046276 RID: 287350 RVA: 0x0126C8E7 File Offset: 0x0126AAE7
		public void UpdateEntityActor(int entityId, AActor actor)
		{
			if (!this.HasInitialized)
			{
				return;
			}
			UKuroJsModelFunctionLibrary.UpdateEntityActor(entityId, actor);
		}

		// Token: 0x06046277 RID: 287351 RVA: 0x0126C8F9 File Offset: 0x0126AAF9
		public void RemoveEntity(int entityId)
		{
			if (!this.HasInitialized)
			{
				return;
			}
			UKuroJsModelFunctionLibrary.RemoveEntity(entityId);
		}

		// Token: 0x0402757B RID: 161147
		public bool HasInitialized;
	}
}
