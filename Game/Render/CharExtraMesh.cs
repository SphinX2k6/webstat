using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Render
{
	// Token: 0x02004749 RID: 18249
	[NullableContext(1)]
	[Nullable(0)]
	public class CharExtraMesh : CharRenderBase
	{
		// Token: 0x0602F5AB RID: 193963 RVA: 0x00B3BA11 File Offset: 0x00B39C11
		public override void Start()
		{
			base.OnInitSuccess();
		}

		// Token: 0x0602F5AC RID: 193964 RVA: 0x00B3BA1C File Offset: 0x00B39C1C
		public void EnsureExtraMesh(string sourceSkeletalName)
		{
			if (this.ExtraMeshes.ContainsKey(sourceSkeletalName))
			{
				return;
			}
			USkeletalMeshComponent skeletalMeshComponent = this.RenderComponent.GetSkeletalMeshComponent(RenderConfig.MaterialControlBodyCaseArray[0]);
			if (skeletalMeshComponent == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.RenderCharacter;
				ELogAuthor author = ELogAuthor.LSY;
				string message = "EnsureExtraMesh未找到源骨骼网格体组件";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("SourceSkeletalName", sourceSkeletalName);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			string text = RenderConfig.GenerateExtraMeshName(sourceSkeletalName);
			AActor cachedOwner = base.GetRenderingComponent().GetCachedOwner();
			TSubclassOf<UActorComponent> @class = USkeletalMeshComponent.StaticClass();
			bool bManualAttachment = false;
			FTransform ftransform = new FTransform();
			USkeletalMeshComponent uskeletalMeshComponent = cachedOwner.AddComponentByClass(@class, bManualAttachment, ftransform, false, new FName(text)) as USkeletalMeshComponent;
			ExtraMeshInfo extraMeshInfo = new ExtraMeshInfo(skeletalMeshComponent, uskeletalMeshComponent, text);
			this.ExtraMeshes[sourceSkeletalName] = extraMeshInfo;
			CharRenderingComponent renderComponent = this.RenderComponent;
			if (renderComponent == null)
			{
				return;
			}
			renderComponent.AddComponentWithEmptyMaterial(extraMeshInfo.Name, uskeletalMeshComponent);
		}

		// Token: 0x0602F5AD RID: 193965 RVA: 0x00B3BADC File Offset: 0x00B39CDC
		public void AddExtraSkeletalMeshUsage(string sourceSkeletalName)
		{
			if (!this.ExtraMeshes.ContainsKey(sourceSkeletalName))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.RenderCharacter;
				ELogAuthor author = ELogAuthor.LSY;
				string message = "找不到ExtraMesh";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("SourceSkeletalName", sourceSkeletalName);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			this.ExtraMeshes[sourceSkeletalName].AddUsage();
		}

		// Token: 0x0602F5AE RID: 193966 RVA: 0x00B3BB30 File Offset: 0x00B39D30
		public void RemoveExtraSkeletalMeshUsage(string sourceSkeletalName)
		{
			if (!this.ExtraMeshes.ContainsKey(sourceSkeletalName))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.RenderCharacter;
				ELogAuthor author = ELogAuthor.LSY;
				string message = "找不到ExtraMesh";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("SourceSkeletalName", sourceSkeletalName);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			this.ExtraMeshes[sourceSkeletalName].RemoveUsage();
		}

		// Token: 0x0602F5AF RID: 193967 RVA: 0x00B3BB84 File Offset: 0x00B39D84
		public override int GetComponentId()
		{
			return 12;
		}

		// Token: 0x0602F5B0 RID: 193968 RVA: 0x00B3BB88 File Offset: 0x00B39D88
		public override string GetStatName()
		{
			return "CharExtraMesh";
		}

		// Token: 0x0401AF73 RID: 110451
		protected Dictionary<string, ExtraMeshInfo> ExtraMeshes = new Dictionary<string, ExtraMeshInfo>();
	}
}
