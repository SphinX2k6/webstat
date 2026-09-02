using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Render
{
	// Token: 0x02004761 RID: 18273
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class CharRenderBase
	{
		// Token: 0x0602F6AE RID: 194222 RVA: 0x00B44390 File Offset: 0x00B42590
		public bool GetIsInitSuc()
		{
			return this.IsInitSuc;
		}

		// Token: 0x0602F6AF RID: 194223 RVA: 0x00B44398 File Offset: 0x00B42598
		[NullableContext(2)]
		public CharRenderingComponent GetRenderingComponent()
		{
			return this.RenderComponent;
		}

		// Token: 0x0602F6B0 RID: 194224 RVA: 0x00B443A0 File Offset: 0x00B425A0
		public void OnInitSuccess()
		{
			this.IsInitSuc = true;
		}

		// Token: 0x0602F6B1 RID: 194225
		public abstract string GetStatName();

		// Token: 0x0602F6B2 RID: 194226 RVA: 0x00B443A9 File Offset: 0x00B425A9
		public virtual void Awake(CharRenderingComponent renderComponent)
		{
			this.RenderComponent = renderComponent;
		}

		// Token: 0x0602F6B3 RID: 194227 RVA: 0x00B443B2 File Offset: 0x00B425B2
		public virtual void Start()
		{
		}

		// Token: 0x0602F6B4 RID: 194228 RVA: 0x00B443B4 File Offset: 0x00B425B4
		public virtual void Update()
		{
		}

		// Token: 0x0602F6B5 RID: 194229 RVA: 0x00B443B6 File Offset: 0x00B425B6
		public virtual void LateUpdate()
		{
		}

		// Token: 0x0602F6B6 RID: 194230 RVA: 0x00B443B8 File Offset: 0x00B425B8
		public virtual void Destroy()
		{
		}

		// Token: 0x0602F6B7 RID: 194231 RVA: 0x00B443BA File Offset: 0x00B425BA
		public virtual void OnResetRenderState()
		{
		}

		// Token: 0x0602F6B8 RID: 194232 RVA: 0x00B443BC File Offset: 0x00B425BC
		public virtual void PreBodyInfoRuntimeInit(FName bodyName)
		{
		}

		// Token: 0x0602F6B9 RID: 194233 RVA: 0x00B443BE File Offset: 0x00B425BE
		public virtual void PostBodyInfoRuntimeInit(FName bodyName)
		{
		}

		// Token: 0x0602F6BA RID: 194234 RVA: 0x00B443C0 File Offset: 0x00B425C0
		protected float GetDeltaTime()
		{
			CharRenderingComponent renderComponent = this.RenderComponent;
			if (renderComponent == null)
			{
				return 0f;
			}
			return renderComponent.GetDeltaTime();
		}

		// Token: 0x0602F6BB RID: 194235
		public abstract int GetComponentId();

		// Token: 0x0602F6BC RID: 194236 RVA: 0x00B443D7 File Offset: 0x00B425D7
		public Stat GetRenderStat()
		{
			if (this.RenderStat == null)
			{
				this.RenderStat = Stat.Create(this.GetStatName(), "", "");
			}
			return this.RenderStat;
		}

		// Token: 0x0401B07A RID: 110714
		[Nullable(2)]
		protected CharRenderingComponent RenderComponent;

		// Token: 0x0401B07B RID: 110715
		[Nullable(2)]
		protected Stat RenderStat;

		// Token: 0x0401B07C RID: 110716
		private bool IsInitSuc;
	}
}
