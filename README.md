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
