using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Map.Marks.MarkItemView.Handles
{
	// Token: 0x02005893 RID: 22675
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class MarkItemComponentHandle<[Nullable(0)] T> : IMarkItemHandle, IMarkItemRangeHandle where T : MarkPanelBase, new()
	{
		// Token: 0x06039A22 RID: 236066 RVA: 0x00E9DFA4 File Offset: 0x00E9C1A4
		public MarkItemComponentHandle(IMarkItemComponentContext context)
		{
			this.Context = context;
		}

		// Token: 0x06039A23 RID: 236067 RVA: 0x00E9DFB3 File Offset: 0x00E9C1B3
		public void Init()
		{
			this.OnInit();
		}

		// Token: 0x06039A24 RID: 236068 RVA: 0x00E9DFBB File Offset: 0x00E9C1BB
		private bool CanExecuteComponentLogic()
		{
			return this.Context.CanExecuteComponentLogic();
		}

		// Token: 0x06039A25 RID: 236069 RVA: 0x00E9DFC8 File Offset: 0x00E9C1C8
		public void Update()
		{
			if (this.CanExecuteComponentLogic())
			{
				this.OnUpdate();
			}
		}

		// Token: 0x06039A26 RID: 236070 RVA: 0x00E9DFD8 File Offset: 0x00E9C1D8
		public void UpdateNoCheck()
		{
			this.OnUpdate();
		}

		// Token: 0x06039A27 RID: 236071 RVA: 0x00E9DFE0 File Offset: 0x00E9C1E0
		public void SetVisible(bool active)
		{
			if (this.CanExecuteComponentLogic())
			{
				this.OnSetVisible(active);
			}
		}

		// Token: 0x06039A28 RID: 236072 RVA: 0x00E9DFF1 File Offset: 0x00E9C1F1
		public void ApplyModified()
		{
			if (this.CanExecuteComponentLogic())
			{
				this.OnApplyModified();
			}
		}

		// Token: 0x06039A29 RID: 236073 RVA: 0x00E9E001 File Offset: 0x00E9C201
		public void ApplyModifiedNoCheck()
		{
			this.OnApplyModified();
		}

		// Token: 0x06039A2A RID: 236074 RVA: 0x00E9E009 File Offset: 0x00E9C209
		public void Dispose()
		{
			this.OnDispose();
		}

		// Token: 0x06039A2B RID: 236075 RVA: 0x00E9E011 File Offset: 0x00E9C211
		protected virtual void OnInit()
		{
		}

		// Token: 0x06039A2C RID: 236076 RVA: 0x00E9E013 File Offset: 0x00E9C213
		protected virtual void OnUpdate()
		{
		}

		// Token: 0x06039A2D RID: 236077 RVA: 0x00E9E015 File Offset: 0x00E9C215
		protected virtual void OnDispose()
		{
			this.DestroyComponent();
		}

		// Token: 0x06039A2E RID: 236078 RVA: 0x00E9E01D File Offset: 0x00E9C21D
		protected virtual void OnSetVisible(bool active)
		{
		}

		// Token: 0x06039A2F RID: 236079 RVA: 0x00E9E01F File Offset: 0x00E9C21F
		protected virtual void OnApplyModified()
		{
		}

		// Token: 0x06039A30 RID: 236080 RVA: 0x00E9E024 File Offset: 0x00E9C224
		protected virtual UniTask PreloadComponentAsync()
		{
			MarkItemComponentHandle<T>.<PreloadComponentAsync>d__16 <PreloadComponentAsync>d__;
			<PreloadComponentAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PreloadComponentAsync>d__.<>4__this = this;
			<PreloadComponentAsync>d__.<>1__state = -1;
			<PreloadComponentAsync>d__.<>t__builder.Start<MarkItemComponentHandle<T>.<PreloadComponentAsync>d__16>(ref <PreloadComponentAsync>d__);
			return <PreloadComponentAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06039A31 RID: 236081 RVA: 0x00E9E068 File Offset: 0x00E9C268
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		protected virtual UniTask<T> LoadComponentAsync()
		{
			MarkItemComponentHandle<T>.<LoadComponentAsync>d__17 <LoadComponentAsync>d__;
			<LoadComponentAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<T>.Create();
			<LoadComponentAsync>d__.<>4__this = this;
			<LoadComponentAsync>d__.<>1__state = -1;
			<LoadComponentAsync>d__.<>t__builder.Start<MarkItemComponentHandle<T>.<LoadComponentAsync>d__17>(ref <LoadComponentAsync>d__);
			return <LoadComponentAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06039A32 RID: 236082 RVA: 0x00E9E0AB File Offset: 0x00E9C2AB
		protected virtual T GetOrCreateComponent()
		{
			return this.ComponentInternal;
		}

		// Token: 0x06039A33 RID: 236083 RVA: 0x00E9E0B3 File Offset: 0x00E9C2B3
		protected virtual void DestroyComponent()
		{
			if (this.ComponentInternal != null)
			{
				this.ComponentInternal.RecycleToPool();
				this.ComponentInternal = default(T);
			}
		}

		// Token: 0x06039A34 RID: 236084 RVA: 0x00E9E0DE File Offset: 0x00E9C2DE
		protected virtual bool IsComponentValid(T component)
		{
			return component.IsStart || component.IsShowOrShowing || component.IsHideOrHiding;
		}

		// Token: 0x06039A35 RID: 236085 RVA: 0x00E9E107 File Offset: 0x00E9C307
		protected static void SetComponentActive(MarkPanelBase component, bool active)
		{
			if (active ? component.IsShow : component.IsHide)
			{
				return;
			}
			component.SetActive(active);
		}

		// Token: 0x04020AE8 RID: 133864
		protected IMarkItemComponentContext Context;

		// Token: 0x04020AE9 RID: 133865
		[Nullable(2)]
		protected T ComponentInternal;
	}
}
