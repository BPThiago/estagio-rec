# Trabalho de Projeto de Sistemas
##### Equipe: Caio Lessa, Marcos dos Santos, Matheus S. Caldas, Thiago Borges

## Diagrama de Pacotes da Arquitetura MVC
```mermaid
graph TB
    subgraph "API REC"
        subgraph Presentation[Presentation Layer]

Controllers[Controllers<br>AlunoController<br>OrientadorController<br>EmpresaController<br>EstagioController]
        end

        subgraph Business[Business Layer]
            subgraph Models[Models]
                Entities[Entities<br>Aluno<br>Orientador<br>Empresa<br>Estagio]
                DTOs[DTOs<br>AlunoDTO<br>OrientadorDTO<br>EmpresaDTO<br>EstagioDTO]
            end
            
            subgraph Repository[Repository]
                Interfaces[Interfaces<br>IAlunoRepository<br>IOrientadorRepository<br>IEmpresaRepository<br>IEstagioRepository]
                Implementations[Implementations<br>AlunoRepository<br>OrientadorRepository<br>EmpresaRepository<br>EstagioRepository]
            end
        end

        subgraph Data[Data Layer]
            Context[Data Context<br>AppDbContext]
            InMemoryDB[In Memory Database]
        end

        Controllers -->|uses| DTOs
        Controllers -->|depends on| Interfaces
        Implementations -->|implements| Interfaces
        Implementations -->|uses| Entities
        Implementations -->|uses| Context
        Context -->|manages| Entities
        Context -->|persists| InMemoryDB

        classDef layer fill:#e6e6e6,stroke:#333,stroke-width:2px
        classDef module fill:#fff,stroke:#666
        class Presentation,Business,Data layer
        class Controllers,Models,Repository,Context,InMemoryDB module
    end
```

## Diagrama de Classes por Camada

### Controller e DTO Layer
```mermaid
classDiagram
    AlunoController --> IAlunoRepository
    OrientadorController --> IOrientadorRepository
    EmpresaController --> IEmpresaRepository
    EstagioController --> IEstagioRepository
    EstagioController --> IAlunoRepository
    EstagioController --> IOrientadorRepository
    EstagioController --> IEmpresaRepository
    AlunoController --> AlunoDTO : uses
    OrientadorController --> OrientadorDTO : uses
    EmpresaController --> EmpresaDTO : uses
    EstagioController --> EstagioDTO : uses
    AlunoDTO --> Aluno : maps to
    OrientadorDTO --> Orientador : maps to
    EmpresaDTO --> Empresa : maps to
    EstagioDTO --> Estagio : maps to

    class AlunoController {
        -IAlunoRepository _alunoRepository
        +CriarAluno(AlunoDTO) Task<ActionResult<Aluno>>
        +ObterAluno(int) Task<ActionResult<Aluno>>
        +ListarAlunos() Task<ActionResult<IEnumerable<Aluno>>>
        +AtualizarAluno(int, AlunoDTO) Task<IActionResult>
        +DeletarAluno(int) Task<IActionResult>
    }

    class OrientadorController {
        -IOrientadorRepository _orientadorRepository
        +CriarOrientador(OrientadorDTO) Task<ActionResult<Orientador>>
        +ObterOrientador(int) Task<ActionResult<Orientador>>
        +ListarOrientadors() Task<ActionResult<IEnumerable<Orientador>>>
        +AtualizarOrientador(int, OrientadorDTO) Task<IActionResult>
        +DeletarOrientador(int) Task<IActionResult>
    }

    class EmpresaController {
        -IEmpresaRepository _empresaRepository
        +CriarEmpresa(EmpresaDTO) Task<ActionResult<Empresa>>
        +ObterEmpresa(int) Task<ActionResult<Empresa>>
        +ListarEmpresas() Task<ActionResult<IEnumerable<Empresa>>>
        +AtualizarEmpresa(int, EmpresaDTO) Task<IActionResult>
        +DeletarEmpresa(int) Task<IActionResult>
    }

    class EstagioController {
        -IEstagioRepository _estagioRepository
        -IAlunoRepository _alunoRepository
        -IOrientadorRepository _orientadorRepository
        -IEmpresaRepository _empresaRepository
        +CriarEstagio(EstagioDTO) Task<ActionResult<Estagio>>
        +ObterEstagio(int) Task<ActionResult<Estagio>>
        +ListarEstagiosPorAluno(int) Task<ActionResult<IEnumerable<Estagio>>>
        +ListarEstagiosPorOrientador(int) Task<ActionResult<IEnumerable<Estagio>>>
        +ListarEstagiosPorAluno(int) Task<ActionResult<IEnumerable<Estagio>>>
        +AtualizarEstagio(int, EstagioDTO) Task<IActionResult>
        +DeletarEstagio(int) Task<IActionResult>
    }

    class AlunoDTO {
        +string Nome
        +string Matricula
    }

    class OrientadorDTO {
        +string Nome
        +string Email
        +string Telefone
    }

    class EmpresaDTO {
        +string Nome
    }
    
    class EstagioDTO {
        +DateTime dtInicio
        +DateTime dtFim
        +SituacaoEnum Situacao
    }
```

### Model Layer
```mermaid
classDiagram
    Aluno "1" -- "*" Estagio
    Orientador "1" -- "*" Estagio
    Empresa "1" -- "*" Estagio
    AppDbContext --> Aluno
    AppDbContext --> Orientador
    AppDbContext --> Empresa
    AppDbContext --> Estagio

    class Aluno {
        +int Id
        +string Nome
        +string Matricula
        +List<Estagio> Estagios
    }

    class Orientador {
        +int Id
        +string Nome
        +string Email
        +string Telefone
        +List<Estagio> Estagios
    }

    class Empresa {
        +int Id
        +string Nome
        +List<Estagio> Estagios
    }

    class Estagio {
        +int Id
        +int AlunoId
        +int OrientadorId
        +int EmpresaId
        +DateTime dtInicio
        +DateTime dtFim
        +SituacaoEnum Situacao
    }

    class AppDbContext {
        +DbSet<Aluno> Alunos
        +DbSet<Orientador> Orientadores
        +DbSet<Empresa> Empresas
        +DbSet<Estagio> Estagios
    }
```

### Repository Layer
```mermaid
classDiagram
    IAlunoRepository <|.. AlunoRepository
    IOrientadorRepository <|.. OrientadorRepository
    IEmpresaRepository <|.. EmpresaRepository
    IEstagioRepository <|.. EstagioRepository
    AlunoRepository --> AppDbContext
    OrientadorRepository --> AppDbContext
    EmpresaRepository --> AppDbContext
    EstagioRepository --> AppDbContext

    class IAlunoRepository {
        <<interface>>
        +ObterPorIdAsync(int) Task<Aluno>
        +ObterTodosAsync(int) Task<IEnumerable<Aluno>>
        +AdicionarAsync(Aluno) Task<Aluno>
        +AtualizarAsync(Aluno) Task
        +DeletarAsync(int) Task
    }

    class IOrientadorRepository {
        <<interface>>
        +ObterPorIdAsync(int) Task<Orientador>
        +ObterTodosAsync() Task<IEnumerable<Orientador>>
        +AdicionarAsync(Orientador) Task<Orientador>
        +AtualizarAsync(Orientador) Task
        +DeletarAsync(int) Task
    }

    class IEmpresaRepository {
        <<interface>>
        +ObterPorIdAsync(int) Task<Empresa>
        +ObterTodosAsync(int) Task<IEnumerable<Empresa>>
        +AdicionarAsync(Empresa) Task<Empresa>
        +AtualizarAsync(Empresa) Task
        +DeletarAsync(int) Task
    }

    class IEstagioRepository {
        <<interface>>
        +ObterPorIdAsync(int) Task<Estagio>
        +ObterTodosAsync(int) Task<IEnumerable<Estagio>>
        +AdicionarAsync(Estagio) Task<Estagio>
        +AtualizarAsync(Estagio) Task
        +DeletarAsync(int) Task
    }

    class AlunoRepository {
        -AppDbContext _context
        +ObterPorIdAsync(int) Task<Aluno>
        +ObterTodosAsync(int) Task<IEnumerable<Aluno>>
        +AdicionarAsync(Aluno) Task<Aluno>
        +AtualizarAsync(Aluno) Task
        +DeletarAsync(int) Task
    }

    class OrientadorRepository {
        -AppDbContext _context
        +ObterPorIdAsync(int) Task<Orientador>
        +ObterTodosAsync() Task<IEnumerable<Orientador>>
        +AdicionarAsync(Orientador) Task<Orientador>
        +AtualizarAsync(Orientador) Task
        +DeletarAsync(int) Task
    }

    class EmpresaRepository {
        -AppDbContext _context
        +ObterPorIdAsync(int) Task<Empresa>
        +ObterTodosAsync(int) Task<IEnumerable<Empresa>>
        +AdicionarAsync(Empresa) Task<Empresa>
        +AtualizarAsync(Empresa) Task
        +DeletarAsync(int) Task
    }

    class EstagioRepository {
        -AppDbContext _context
        +ObterPorIdAsync(int) Task<Estagio>
        +ObterTodosAsync(int) Task<IEnumerable<Estagio>>
        +AdicionarAsync(Estagio) Task<Estagio>
        +AtualizarAsync(Estagio) Task
        +DeletarAsync(int) Task
    }
```
